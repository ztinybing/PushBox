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
    public partial class BoxItemPropEidtUI : UserControl
    {
        public BoxItemPropEidtUI()
        {
            InitializeComponent();
        }
        private BoxItem boxItem = null;
        public BoxItem BoxItem
        {
            get
            {
                return this.boxItem;
            }
            set
            {
                this.boxItem = value;
                InitByBoxItem(value);
            } 
        }
        /// <summary>
        /// �󶨿�ͨ���Ԫ��CanCross
        /// </summary>
        /// <param name="boxItem">�󶨵���Ԫ��</param>
        private void InitByBoxItem(BoxItem boxItem)
        {
            if (boxItem == null)
            {
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            this.ceCross.DataBindings.Clear();
            this.ceCross.DataBindings.Add("Checked", boxItem, "CanCross");
        }
        /// <summary>
        /// ���ϣ�ͼƬѡ��
        /// </summary>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (boxItem == null) return;
            new ImageSelecedFrm(boxItem.UpImageList).ShowDialog();
        }
        /// <summary>
        /// ����ͼƬѡ��
        /// </summary>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (boxItem == null) return;
            new ImageSelecedFrm(boxItem.LeftImageList).ShowDialog();
        }
        /// <summary>
        /// ���ң�ͼƬѡ��
        /// </summary>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (boxItem == null) return;
            new ImageSelecedFrm(boxItem.RightImageList).ShowDialog();
        }
        /// <summary>
        /// ���£�ͼƬѡ��
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (boxItem == null) return;
            new ImageSelecedFrm(boxItem.DownImageList).ShowDialog();
        }
    }
}
