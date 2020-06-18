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
        /// 绑定可通过项到元素CanCross
        /// </summary>
        /// <param name="boxItem">绑定到的元素</param>
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
        /// 向上，图片选择
        /// </summary>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (boxItem == null) return;
            new ImageSelecedFrm(boxItem.UpImageList).ShowDialog();
        }
        /// <summary>
        /// 向左，图片选择
        /// </summary>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (boxItem == null) return;
            new ImageSelecedFrm(boxItem.LeftImageList).ShowDialog();
        }
        /// <summary>
        /// 向右，图片选择
        /// </summary>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (boxItem == null) return;
            new ImageSelecedFrm(boxItem.RightImageList).ShowDialog();
        }
        /// <summary>
        /// 向下，图片选择
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (boxItem == null) return;
            new ImageSelecedFrm(boxItem.DownImageList).ShowDialog();
        }
    }
}
