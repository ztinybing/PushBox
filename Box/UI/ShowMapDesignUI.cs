using System;
using System.Collections.Generic;
using System.Text;
using Game.Box;
using System.Drawing;
using System.Windows.Forms;

namespace Box.UI
{
    public class ShowMapDesignUI : ShowMapUI
    {
        public ShowMapDesignUI()
            : base()
        {
            EventRegist();
        }
        public ShowMapDesignUI(BoxGame boxGame)
            : base(boxGame)
        {
        }
        private void EventRegist()
        {
            this.MovePointChanged += new MovePointChangeEventHandler(ShowMapUI_MovePointChanged);
            this.MouseLeave += new System.EventHandler(this.ShowMapUI_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.showMapUI_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShowMapUI_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShowMapUI_MouseUp);
            this.MouseWheel += new MouseEventHandler(ShowMapUI_MouseWheel);
        }
        /// <summary>
        /// 鼠标移动到的点,编辑模式用
        /// </summary>
        private Point? movePoint = null;
        private uint designLayer = 1;
        /// <summary>
        /// 获取或设置当前设计层
        /// </summary>
        public uint DesignLayer
        {
            get { return this.designLayer; }
            set
            {
                this.designLayer = value;
                if (!showAllLayer) this.Refresh();
            }
        }
        private bool showAllLayer = true;
        /// <summary>
        /// 是否显示所有层
        /// </summary>
        public bool ShowAllLayer
        {
            get { return this.showAllLayer; }
            set
            {
                this.showAllLayer = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 当前设计选中预置体
        /// </summary>
        public BoxItem DesignBoxItem = null;

        private static readonly object EventPointChange = new object();
        /// <summary>
        /// 移动点改变事件
        /// </summary>
        public event MovePointChangeEventHandler MovePointChanged
        {
            add
            {
                base.Events.AddHandler(EventPointChange, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventPointChange, value);
            }
        }
        protected override void ShowMapUI_Resize(object sender, EventArgs e)
        {

        }
        protected override void ShowLayerEdit(List<uint> layerList)
        {
            //显示所有层
            if (ShowAllLayer)
            {
                base.ShowLayerEdit(layerList);
            }
            else
            {
                //显示指定层
                if (BoxGame.LayerMapDict.ContainsKey(designLayer))
                {
                    layerList.Add(designLayer);
                }
                else//还没有的层显示空白
                {
                }
            }
        }
        protected override void ShowMapUI_Paint(object sender, PaintEventArgs e)
        {
            base.ShowMapUI_Paint(sender, e);
            //移动点显示红框
            if (movePoint != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, movePoint.Value.X * unit + BorderUnit, movePoint.Value.Y * unit + BorderUnit, unit, unit);
            }
        }
        /// <summary>
        /// 鼠标移动，设置移动点
        /// </summary>
        private void showMapUI_MouseMove(object sender, MouseEventArgs e)
        {
            int x = (int)Math.Floor((double)(e.Location.X + this.BorderUnit) / this.Unit);
            int y = (int)Math.Floor((double)(e.Location.Y + this.BorderUnit) / this.Unit);
            Point newPoint = new Point(x, y);
            if (movePoint != null && movePoint.Value == newPoint) return;

            //触发移动点改变事件
            MovePointChangeEventHandler eventHandler = base.Events[EventPointChange] as MovePointChangeEventHandler;
            if (eventHandler != null) eventHandler(this, new MovePointChangeEventArgs(movePoint == null ? new Point(-1, -1) : movePoint.Value, newPoint));

            movePoint = new Point(x, y);
            this.Refresh();
        }
        /// <summary>
        /// 鼠标移动出控件，移动点置空
        /// </summary>
        private void ShowMapUI_MouseLeave(object sender, EventArgs e)
        {
            movePoint = null;
            this.Refresh();
        }
        /// <summary>
        /// 鼠标滚轮缩放大小
        /// </summary>
        private void ShowMapUI_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;
            if (delta == 0) return;
            int val = (int)(unit * (delta > 0 ? 1.2 : 5d / 6));
            unit = val == unit ? (delta > 0 ? unit + 1 : unit - 1) : val;
            if (unit < 2) unit = 2;
            this.Refresh();
        }
        #region 地图设计相关
        private void ShowMapUI_MovePointChanged(object sender, MovePointChangeEventArgs e)
        {
            //移动点设置地图
            SetPointMap(e.NewPoint);
        }
        /// <summary>
        /// 设置当前预置到地图目标点
        /// </summary>
        /// <param name="targetPoint"></param>
        private void SetPointMap(Point targetPoint)
        {
            if (BoxGame == null) return;
            if (!designing || this.DesignBoxItem == null) return;

            if (!BoxGame.LayerMapDict.ContainsKey(DesignLayer)) BoxGame.LayerMapDict.Add(DesignLayer, new BoxMap());
            if (this.DesignBoxItem.DefaultImg == "Delete")
            {
                BoxGame.LayerMapDict[DesignLayer].Remove(targetPoint);
            }
            else
            {
                BoxGame.LayerMapDict[DesignLayer][targetPoint] = this.DesignBoxItem.Clone();
            }

        }

        /// <summary>
        /// 设计中标志，鼠标按下时移动鼠标可连续设计
        /// </summary>
        private bool designing = false;
        private void ShowMapUI_MouseDown(object sender, MouseEventArgs e)
        {
            designing = true;
            if (movePoint != null)
            {
                SetPointMap(movePoint.Value);//当前点击点设置地图
            }
        }

        private void ShowMapUI_MouseUp(object sender, MouseEventArgs e)
        {
            designing = false;
        }
        #endregion
        public delegate void MovePointChangeEventHandler(object sender, MovePointChangeEventArgs e);
        /// <summary>
        /// 点移动事件参数
        /// </summary>
        public class MovePointChangeEventArgs : EventArgs
        {
            Point oldPoint;
            /// <summary>
            /// 改变前的点坐标
            /// </summary>
            public Point OldPoint
            {
                get { return oldPoint; }
            }
            Point newPoint;
            /// <summary>
            /// 改变后的点坐标
            /// </summary>
            public Point NewPoint
            {
                get { return newPoint; }
            }
            public MovePointChangeEventArgs(Point oldPoint, Point newPoint)
            {
                this.oldPoint = oldPoint;
                this.newPoint = newPoint;
            }
        }
    }
}
