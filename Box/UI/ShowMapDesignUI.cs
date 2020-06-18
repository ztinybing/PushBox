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
        /// ����ƶ����ĵ�,�༭ģʽ��
        /// </summary>
        private Point? movePoint = null;
        private uint designLayer = 1;
        /// <summary>
        /// ��ȡ�����õ�ǰ��Ʋ�
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
        /// �Ƿ���ʾ���в�
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
        /// ��ǰ���ѡ��Ԥ����
        /// </summary>
        public BoxItem DesignBoxItem = null;

        private static readonly object EventPointChange = new object();
        /// <summary>
        /// �ƶ���ı��¼�
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
            //��ʾ���в�
            if (ShowAllLayer)
            {
                base.ShowLayerEdit(layerList);
            }
            else
            {
                //��ʾָ����
                if (BoxGame.LayerMapDict.ContainsKey(designLayer))
                {
                    layerList.Add(designLayer);
                }
                else//��û�еĲ���ʾ�հ�
                {
                }
            }
        }
        protected override void ShowMapUI_Paint(object sender, PaintEventArgs e)
        {
            base.ShowMapUI_Paint(sender, e);
            //�ƶ�����ʾ���
            if (movePoint != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, movePoint.Value.X * unit + BorderUnit, movePoint.Value.Y * unit + BorderUnit, unit, unit);
            }
        }
        /// <summary>
        /// ����ƶ��������ƶ���
        /// </summary>
        private void showMapUI_MouseMove(object sender, MouseEventArgs e)
        {
            int x = (int)Math.Floor((double)(e.Location.X + this.BorderUnit) / this.Unit);
            int y = (int)Math.Floor((double)(e.Location.Y + this.BorderUnit) / this.Unit);
            Point newPoint = new Point(x, y);
            if (movePoint != null && movePoint.Value == newPoint) return;

            //�����ƶ���ı��¼�
            MovePointChangeEventHandler eventHandler = base.Events[EventPointChange] as MovePointChangeEventHandler;
            if (eventHandler != null) eventHandler(this, new MovePointChangeEventArgs(movePoint == null ? new Point(-1, -1) : movePoint.Value, newPoint));

            movePoint = new Point(x, y);
            this.Refresh();
        }
        /// <summary>
        /// ����ƶ����ؼ����ƶ����ÿ�
        /// </summary>
        private void ShowMapUI_MouseLeave(object sender, EventArgs e)
        {
            movePoint = null;
            this.Refresh();
        }
        /// <summary>
        /// ���������Ŵ�С
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
        #region ��ͼ������
        private void ShowMapUI_MovePointChanged(object sender, MovePointChangeEventArgs e)
        {
            //�ƶ������õ�ͼ
            SetPointMap(e.NewPoint);
        }
        /// <summary>
        /// ���õ�ǰԤ�õ���ͼĿ���
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
        /// ����б�־����갴��ʱ�ƶ������������
        /// </summary>
        private bool designing = false;
        private void ShowMapUI_MouseDown(object sender, MouseEventArgs e)
        {
            designing = true;
            if (movePoint != null)
            {
                SetPointMap(movePoint.Value);//��ǰ��������õ�ͼ
            }
        }

        private void ShowMapUI_MouseUp(object sender, MouseEventArgs e)
        {
            designing = false;
        }
        #endregion
        public delegate void MovePointChangeEventHandler(object sender, MovePointChangeEventArgs e);
        /// <summary>
        /// ���ƶ��¼�����
        /// </summary>
        public class MovePointChangeEventArgs : EventArgs
        {
            Point oldPoint;
            /// <summary>
            /// �ı�ǰ�ĵ�����
            /// </summary>
            public Point OldPoint
            {
                get { return oldPoint; }
            }
            Point newPoint;
            /// <summary>
            /// �ı��ĵ�����
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
