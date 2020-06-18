using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Game.Box;

namespace Box.UI
{
    public partial class ShowMapUI : UserControl
    {
        public ShowMapUI()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//双缓存，防闪烁
        }
        public ShowMapUI(BoxGame boxGame)
            : this()
        {
            this.boxGame = boxGame;
        }
        protected BoxGame boxGame = null;
        public BoxGame BoxGame
        {
            get
            {
                if (this.boxGame == null) this.boxGame = new BoxGame();
                return this.boxGame;
            }
            set
            {
                this.boxGame = value;
            }
        }

        /// <summary>
        /// 离边距距离
        /// </summary>
        public int BorderUnit = 1;
        protected int unit = 10;
        /// <summary>
        /// 每个格子单位长度
        /// </summary>
        public int Unit
        {
            get { return unit; }
        }

        #region 事件处理函数
        /// <summary>
        /// 在非编辑模式重设控件大小时，适配格子长度
        /// </summary>
        protected virtual void ShowMapUI_Resize(object sender, EventArgs e)
        {
            //todo
        }
        protected virtual void ShowLayerEdit(List<uint> layerList)
        {
            //显示所有层
            layerList.AddRange(BoxGame.LayerMapDict.Keys);
        }
        /// <summary>
        /// 绘制背景，前景，移动点
        /// </summary>
        protected virtual void ShowMapUI_Paint(object sender, PaintEventArgs e)
        {
            if (BoxGame == null) return;
            List<uint> layerList = new List<uint>();
            ShowLayerEdit(layerList);
            layerList.Sort();//按层次依次显示
            //显示层次中物体
            foreach (uint layer in layerList)
            {
                foreach (KeyValuePair<Point, BoxItem> item in BoxGame.LayerMapDict[layer])
                {
                    BoxItem bbItem = item.Value;
                    if (item.Value == null) continue;
                    Rectangle rectangle = new Rectangle(item.Key.X * unit + BorderUnit, item.Key.Y * unit + BorderUnit, unit, unit);
                    if (layer == (uint)LayerOptions.Role)
                    {
                        e.Graphics.DrawImage(ImageManager.Instance[bbItem.GetImgName(this.boxGame.CharacterDirection, this.boxGame.CharacterTimerCount)], rectangle);
                    }
                    else
                    {
                        e.Graphics.DrawImage(ImageManager.Instance[bbItem.DefaultImg], rectangle);
                    }
                }
            }
        }
        #endregion
    }

}
