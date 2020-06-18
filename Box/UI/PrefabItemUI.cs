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
    /// <summary>
    /// Ԥ����UI
    /// </summary>
    public partial class PrefabItemUI : UserControl
    {
        public PrefabItemUI()
        {
            InitializeComponent();
        }
        BoxItem boxItem = null;
        public BoxItem BoxItem
        {
            get { return this.boxItem; }
        }
        /// <summary>
        /// ����Ԥ����UI
        /// </summary>
        /// <param name="boxItem"></param>
        public PrefabItemUI(BoxItem boxItem)
            : this()
        {
            this.boxItem = boxItem;
            InitImage();
        }
        private void InitImage()
        {
            if (boxItem == null) return;
            this.peMain.Image = ImageManager.Instance[boxItem.GetImgName(this.ShowDirection, this.showIndex)];
            this.peMain.Image = new Bitmap(this.peMain.Image, new Size(this.peMain.Width - 3, this.peMain.Height - 3));
        }
        private DirectionOptions showDirection = DirectionOptions.Down;
        /// <summary>
        /// ��ʾ����
        /// </summary>
        public DirectionOptions ShowDirection
        {
            get { return this.showDirection; }
            set
            {
                this.showDirection = value;
                //�ı䷽������ͼƬ����
                this.ShowIndex = 0;
            }
        }

        private int showIndex = 0;
        /// <summary>
        /// ��ʾ��ǰ����ͼƬ������������ȡ��
        /// </summary>
        public int ShowIndex
        {
            get { return this.showIndex; }
            set
            {
                this.showIndex = value;
                //�޸�������ͬ��ͼƬ
                InitImage();
            }
        }

        private bool isSelected = false;
        /// <summary>
        /// �Ƿ��ǽ������ɫ�߿��ʾ
        /// </summary>
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.Refresh();
                }
            }
        }

        private void peMain_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
        /// <summary>
        /// ��������ƺ�ɫ�߿�
        /// </summary>
        private void PrefabItem_Paint(object sender, PaintEventArgs e)
        {
            if (!this.isSelected) return;
            e.Graphics.DrawRectangle(Pens.Red, 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}
