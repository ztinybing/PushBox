using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game.Box
{
    public class BoxGame : IMoveable
    {
        uint stage = 1;
        //当前关卡地图
        SerializableDictionary<uint, BoxMap> layerMapDict = new SerializableDictionary<uint, BoxMap>();
        public SerializableDictionary<uint, BoxMap> LayerMapDict
        {
            get
            {
                return this.layerMapDict;
            }
        }
        private DirectionOptions characterDirection = DirectionOptions.Down;
        public int CharacterTimerCount = 0;
        /// <summary>
        /// 角色当前方向
        /// </summary>
        public DirectionOptions CharacterDirection
        {
            get { return this.characterDirection; }
        }
        /// <summary>
        /// 获取或设置关卡，若没有设置关卡，则不设置
        /// </summary>
        public uint Stage
        {
            get { return this.stage; }
            set
            {
                uint oldStage = stage;
                stage = value;
                if (!File.Exists(StageMapPath)) stage = oldStage;
                else LoadStage(value);

            }
        }
        public void ForceSetStage(uint stage)
        {
            this.stage = stage;
            LoadStage(stage);
        }
        /// <summary>
        /// 关卡保存路径
        /// </summary>
        private string StageMapPath
        {
            get
            {
                return Path.Combine(PathManager.StageMapFolder, string.Concat(stage, ".xml"));
            }
        }
        /// <summary>
        /// 已存在关卡
        /// </summary>
        public List<uint> existStageList
        {
            get
            {
                List<uint> stageList = new List<uint>();
                uint tempStage = 0;
                foreach (string filePath in Directory.GetFiles(PathManager.StageMapFolder))
                {

                    if (uint.TryParse(Path.GetFileNameWithoutExtension(filePath), out   tempStage) && !stageList.Contains(tempStage))
                    {
                        stageList.Add(tempStage);
                    }
                }
                stageList.Sort();
                return stageList;
            }
        }

        #region 事件
        private Action<MatchResult> StageCompleteEventHandler;
        /// <summary>
        /// 通关事件
        /// </summary>
        public event Action<MatchResult> StageComplete
        {
            add { this.StageCompleteEventHandler += value; }
            remove { this.StageCompleteEventHandler -= value; }
        }

        private Action<uint> StageLoadedEventHanlder;
        /// <summary>
        /// 关卡加载事件
        /// </summary>
        public event Action<uint> StageLoaded
        {
            add { this.StageLoadedEventHanlder += value; }
            remove { StageLoadedEventHanlder -= value; }
        }
        #endregion

        public BoxGame()
        {
            layerMapDict.ItemAdd += new Action<KeyValuePair<uint, BoxMap>>(layerMapDict_ItemAdd);//注册地图层次添加事件
            this.StageComplete += new Action<MatchResult>(BoxGame_StageComplete);//注册通关事件
            LoadStage(this.stage);
        }
        #region 通关事件及处理函数
        /// <summary>
        /// 通关处理函数
        /// </summary>
        /// <param name="obj">通关结果</param>
        void BoxGame_StageComplete(MatchResult obj)
        {
            //加载下一个
            this.GoNextStage();
        }
        /// <summary>
        /// 地图层添加处理函数
        /// </summary>
        /// <param name="obj"></param>
        void layerMapDict_ItemAdd(KeyValuePair<uint, BoxMap> obj)
        {
            if (obj.Key == (uint)LayerOptions.Box)//箱子层
            {
                obj.Value.ItemAdd += new Action<BoxMap>(Value_ItemAdd);//注册箱子（添加）移动事件
            }
        }
        /// <summary>
        /// 箱子层添加箱子事件（移动则为先移除再添加）
        /// </summary>
        /// <param name="boxLayerMap"></param>
        void Value_ItemAdd(BoxMap boxLayerMap)
        {
            if (StageCompleteEventHandler == null) return;
            uint targetLayer = (uint)LayerOptions.Target;//目标层
            if (!this.layerMapDict.ContainsKey(targetLayer)) return;
            //检测箱子层和目标点层
            MatchResult result = CheckResult(this.layerMapDict[targetLayer], boxLayerMap);
            //通关则触发通关事件
            if (result.IsComplete) StageCompleteEventHandler(result);
        }
        /// <summary>
        /// 检测目标层和箱子层重合结果
        /// </summary>
        /// <param name="targetMap">目标层</param>
        /// <param name="boxMap">箱子层</param>
        /// <returns>重合结果</returns>
        private MatchResult CheckResult(BoxMap targetMap, BoxMap boxMap)
        {
            MatchResult result = new MatchResult();
            foreach (Point targetPoint in targetMap.Keys)
            {
                result.TargetCount++;
            }
            foreach (Point boxPoint in boxMap.Keys)
            {
                result.BoxCount++;
                if (targetMap.ContainsKey(boxPoint)) result.MatchedCount++;
            }
            return result;
        }

        #endregion

        #region 函数
        /// <summary>
        /// 根据点获取该点上所有的BoxItem
        /// </summary>
        internal PointMapDictionary PointMapDict
        {
            get
            {
                PointMapDictionary dict = new PointMapDictionary();
                foreach (BoxMap map in layerMapDict.Values)
                {
                    foreach (KeyValuePair<Point, BoxItem> pair in map)
                    {
                        dict[pair.Key].Add(pair.Value);
                    }
                }
                return dict;
            }
        }
        /// <summary>
        /// 获取指定点上BoxItem
        /// </summary>
        /// <param name="pos">指定点</param>
        /// <returns>key:层 value:boxItem</returns>
        private Dictionary<uint, BoxItem> GetBoxItemsByPoint(Point pos)
        {
            Dictionary<uint, BoxItem> dict = new Dictionary<uint, BoxItem>();
            foreach (KeyValuePair<uint, BoxMap> pair in LayerMapDict)
            {
                if (pair.Value.ContainsKey(pos))
                {
                    dict[pair.Key] = pair.Value[pos];
                }
            }
            return dict;
        }

        #region 关卡保存相关

        /// <summary>
        /// 保存当前关卡模板
        /// </summary>
        public void SaveToStage()
        {
            SaveStage(this.StageMapPath);
        }
        /// <summary>
        /// 保存当前关卡模板
        /// </summary>
        /// <param name="path">保存路径</param>
        private void SaveStage(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(SerializableDictionary<uint, BoxMap>));
            using (FileStream fs = new FileStream(this.StageMapPath, File.Exists(this.StageMapPath) ? FileMode.Truncate : FileMode.Create))
            {
                xs.Serialize(fs, this.layerMapDict);
            }
        }
        /// <summary>
        /// 加载关卡
        /// </summary>
        /// <param name="stage">关卡</param>
        public void LoadStage(uint stage)
        {
            string stageMapPath = this.StageMapPath;
            layerMapDict.Clear();
            if (!File.Exists(stageMapPath)) return;
            XmlSerializer xs = new XmlSerializer(typeof(SerializableDictionary<uint, BoxMap>));
            using (FileStream fs = new FileStream(stageMapPath, FileMode.Open))
            {
                //layerMapDict = xs.Deserialize(fs) as SerializableDictionary<uint, BoxMap>;//这种方式会重新生成SerializableDictionary<uint, BoxMap>,则不会触发原layerMapDict上事件
                foreach (KeyValuePair<uint, BoxMap> pair in xs.Deserialize(fs) as SerializableDictionary<uint, BoxMap>)
                {
                    layerMapDict.Add(pair.Key, pair.Value);
                }
            }
            if (StageLoadedEventHanlder != null) StageLoadedEventHanlder(stage);
        }

        /// <summary>
        /// 保存当前状态
        /// </summary>
        public void SaveCurState()
        {
            string stateStage = Path.Combine(PathManager.StateSaveFolder, string.Concat(stage, ".xml"));
            SaveStage(stateStage);
        }
        #endregion
        /// <summary>
        /// 清空指定层内数据
        /// </summary>
        /// <param name="layer">被清空的层</param>
        public void ClearLayer(uint layer)
        {
            if (!this.layerMapDict.ContainsKey(layer)) return;
            this.layerMapDict[layer].Clear();
        }
        /// <summary>
        /// 设置到下一关卡，若已经到最后关卡则置为1
        /// </summary>
        public void GoNextStage()
        {
            uint oldSatage = this.Stage;
            this.Stage++;
            if (oldSatage == this.Stage) this.Stage = 1;
        }
        /// <summary>
        /// 根据基点获取指定方向上的邻接点
        /// </summary>
        /// <param name="basePoint">基点</param>
        /// <param name="dir">指定方向</param>
        /// <returns>指定方向上的邻接点</returns>
        private Point GetPointByDir(Point basePoint, DirectionOptions dir)
        {
            switch (dir)
            {
                case DirectionOptions.Up: return new Point(basePoint.X, basePoint.Y - 1);
                case DirectionOptions.Down: return new Point(basePoint.X, basePoint.Y + 1);
                case DirectionOptions.Left: return new Point(basePoint.X - 1, basePoint.Y);
                case DirectionOptions.Right: return new Point(basePoint.X + 1, basePoint.Y);
            }
            return basePoint;
        }
        /// <summary>
        /// 向指定方向移动
        /// </summary>
        /// <param name="dirOpt">指定方向</param>
        /// <returns>是否移动成功</returns>
        private bool Move(DirectionOptions dirOpt)
        {
            this.characterDirection = dirOpt;
            this.CharacterTimerCount = 0;
            uint roleLayer = (uint)LayerOptions.Role;
            if (!this.LayerMapDict.ContainsKey(roleLayer)) return false;
            List<KeyValuePair<Point, BoxItem>> rolePairList = new List<KeyValuePair<Point, BoxItem>>();

            foreach (KeyValuePair<Point, BoxItem> pair in this.LayerMapDict[roleLayer])
            {
                rolePairList.Add(pair);
            }
            foreach (KeyValuePair<Point, BoxItem> pair in rolePairList)
            {
                this.LayerMapDict[roleLayer].Remove(pair.Key);
            }
            bool moved = false;//是否移动成功
            foreach (KeyValuePair<Point, BoxItem> pair in rolePairList)
            {
                bool canMove = CanMoveTo(pair.Key, dirOpt, true);
                if (!moved && canMove) moved = true;
                if (!canMove)
                {
                    this.LayerMapDict[roleLayer][pair.Key] = pair.Value;
                    continue;
                }
                Point neighborPoint = GetPointByDir(pair.Key, dirOpt);
                this.LayerMapDict[roleLayer][neighborPoint] = pair.Value;
                foreach (KeyValuePair<uint, BoxItem> layerMapPair in this.GetBoxItemsByPoint(neighborPoint))
                {
                    if (layerMapPair.Key == (uint)LayerOptions.Box)
                    {
                        layerMapDict[layerMapPair.Key].Remove(neighborPoint);
                        layerMapDict[layerMapPair.Key][GetPointByDir(neighborPoint, dirOpt)] = layerMapPair.Value;
                    }
                }
            }

            return moved;
        }
        /// <summary>
        /// 是否能向指定方向移动
        /// </summary>
        /// <param name="basePoint">当前点</param>
        /// <param name="dirOpt">指定方向</param>
        /// <param name="isRole">当前点是否是角色</param>
        /// <returns>是否能移动</returns>
        private bool CanMoveTo(Point basePoint, DirectionOptions dirOpt, bool isRole)
        {
            Point neighborPoint = GetPointByDir(basePoint, dirOpt);
            bool canMove = true;
            foreach (KeyValuePair<uint, BoxItem> layerBoxPair in GetBoxItemsByPoint(neighborPoint))
            {
                //角色点移动方向是箱子，则再判断箱子能否向该方向移动
                if (isRole && layerBoxPair.Key == (uint)LayerOptions.Box)
                {
                    canMove &= CanMoveTo(neighborPoint, dirOpt, false);
                    continue;
                }
                canMove &= layerBoxPair.Value.CanCross;
            }
            return canMove;
        }
        #endregion

        #region IMoveable 成员
        public bool Up()
        {
            return Move(DirectionOptions.Up);
        }

        public bool Down()
        {
            return Move(DirectionOptions.Down);
        }

        public bool Left()
        {
            return Move(DirectionOptions.Left);
        }

        public bool Right()
        {
            return Move(DirectionOptions.Right);
        }
        #endregion
    }
}
