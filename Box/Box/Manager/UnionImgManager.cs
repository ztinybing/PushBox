using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Game.Box
{
    /// <summary>
    /// 图片合成效果管理器
    /// </summary>
    public class UnionImgManager:IEnumerable<UnionItem>
    {
        private static UnionImgManager _instance;
        public static UnionImgManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UnionImgManager();
                }
                return _instance;
            }
        }

        private static string unionImgPath;
        /// <summary>
        /// 合成效果文件保存路径
        /// </summary>
        private static string UnionImgPath
        {
            get
            {
                if (unionImgPath == null)
                {
                    unionImgPath = Path.Combine(PathManager.UnionImgFolder, "UnionSettings.xml");
                }
                return unionImgPath;
            }
        }

        private List<UnionItem> unionItemList = new List<UnionItem>();
        private UnionImgManager()
        {
            if (!File.Exists(UnionImgPath)) return;
            XmlSerializer xs = new XmlSerializer(typeof(List<UnionItem>));
            using (Stream stream = new FileStream(UnionImgPath, FileMode.Open))
            {
                unionItemList = xs.Deserialize(stream) as List<UnionItem>;
            }
        }
        public void Add(UnionItem item)
        {
            unionItemList.Add(item);
        }
        public UnionItem AddNew()
        {
            UnionItem item = new UnionItem();
            unionItemList.Add(item);
            return item;
        }
        public void Remove(UnionItem item)
        {
            this.unionItemList.Remove(item);
        }
        public UnionItem this[int index]
        {
            get
            {
                return this.unionItemList[index];
            }
        }
        public int Count
        {
            get { return this.unionItemList.Count; }
        }
        /// <summary>
        /// 保存合成效果配置到xml
        /// </summary>
        public void Save()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<UnionItem>));
            using (Stream stream = new FileStream(UnionImgPath, File.Exists(UnionImgPath) ? FileMode.Truncate : FileMode.CreateNew))
            {
                xs.Serialize(stream, unionItemList);
            }
        }
        /// <summary>
        /// 根据合成源查找合成结果
        /// </summary>
        /// <param name="sources">合成源集合</param>
        /// <returns>合成源对应合成结果项，若没有则返回null</returns>
        public UnionItem GetUnionItem(params string[] sources)
        {
            foreach (UnionItem unionItem in unionItemList)
            {
                bool matched = true;
                foreach (string source in sources)
                {
                    if (!unionItem.SourceList.Contains(source))
                    {
                        matched = false;
                        break;
                    }
                }
                if (matched) return unionItem;
            }
            return null;
        }

        #region IEnumerable<UnionItem> 成员

        public IEnumerator<UnionItem> GetEnumerator()
        {
            return this.unionItemList.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.unionItemList.GetEnumerator();
        }

        #endregion
    }
    /// <summary>
    /// 合成项
    /// </summary>
    [Serializable]
    public class UnionItem
    {
        private List<string> sourceList = new List<string>();
        /// <summary>
        /// 合成来源
        /// </summary>
        public List<string> SourceList
        {
            get
            {
                return sourceList;
            }
            set
            {
                this.sourceList = value;
            }
        }
        private List<string> unionResultList = new List<string>();
        /// <summary>
        /// 合成结果
        /// </summary>
        public List<string> UnionResultList
        {
            get { return unionResultList; }
            set { unionResultList = value; }
        }
        /// <summary>
        /// 添加合成源
        /// </summary>
        /// <param name="source">合成源名称</param>
        public UnionItem AddSource(string source)
        {
            if (sourceList.Contains(source)) return this;
            sourceList.Add(source);
            return this;
        }
        /// <summary>
        /// 移除合成源
        /// </summary>
        /// <param name="source">合成源名称</param>
        public UnionItem RemoveSource(string source)
        {
            sourceList.Remove(source);
            return this;
        }
        /// <summary>
        /// 添加合成结果
        /// </summary>
        /// <param name="unionResult">合成结果名称</param>
        public UnionItem AddUnionResult(string unionResult)
        {
            if (this.unionResultList.Contains(unionResult)) return this;
            unionResultList.Add(unionResult);
            return this;
        }
        /// <summary>
        /// 移除合成结果
        /// </summary>
        /// <param name="unionResult">合成结果名称</param>
        public UnionItem RemoveUnionResult(string unionResult)
        {
            unionResultList.Remove(unionResult);
            return this;
        }
    }
}
