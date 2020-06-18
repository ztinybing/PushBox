using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Game.Box;

namespace Box.UI
{
    public partial class ImgSelectUI : UserControl
    {
        public ImgSelectUI()
        {
            InitializeComponent();
            InitAllImg();
        }
        private List<string> imgNameList = new List<string>();
        public List<string> ImgNameList
        {
            get
            {
                return this.imgNameList;
            }
            set
            {
                this.imgNameList = value;
                imgListSelectResult.Items.Clear();
                InitCurImg();
            }
        }
        #region 函数
        public void SetResult()
        {
            this.imgNameList.Clear();
            foreach (ListBoxItem item in imgListSelectResult.Items)
            {
                imgNameList.Add(item.Value.ToString());
            }
        }
        /// <summary>
        /// 初始化所有备选项
        /// </summary>
        public void InitAllImg()
        {
            for (int i = 0; i < ImageManager.Instance.ImgKeys.Count; i++)
            {
                string name = ImageManager.Instance.ImgKeys[i];
                imgListSource.Images.Add(name, ImageManager.Instance[name]);
                imgListAll.Items.Add(name, i);
            }
        }
        /// <summary>
        /// 初始化当前选项
        /// </summary>
        private void InitCurImg()
        {
            for (int i = 0; i < imgNameList.Count; i++)
            {
                string name = imgNameList[i];
                AddToImgListSelect(name);
            }
        }
        /// <summary>
        /// 添加到已选项，并设置图片序号
        /// </summary>
        /// <param name="name">图片名称</param>
        private void AddToImgListSelect(string name)
        {
            int imgIndex = ImageManager.Instance.ImgKeys.IndexOf(name);
            if (imgIndex >= 0)
            {
                imgListSelectResult.Items.Add(name, imgIndex);
            }
            else
            {
                imgListSelectResult.Items.Add(name);
            }
        }
        /// <summary>
        /// 从备选控件添加到选择结果控件
        /// </summary>
        public void AddFromImgListAll()
        {
            string selectedName = (imgListAll.SelectedItem as ListBoxItem).Value.ToString();
            if (string.IsNullOrEmpty(selectedName)) return;//不判断重复，可添加重复名称项
            AddToImgListSelect(selectedName);
        }

        /// <summary>
        /// 从选择结果控件移除焦点项
        /// </summary>
        public void RemoveCurSelect()
        {
            int selectedIndex = imgListSelectResult.SelectedIndex;
            if (selectedIndex < 0) return;
            imgListSelectResult.Items.RemoveAt(selectedIndex);
        } 
        #endregion
        #region 事件处理函数
        /// <summary>
        /// 点击添加（向右箭头）， 备选项添加到选择结果
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.AddFromImgListAll();
        }
        /// <summary>
        /// 双击备选项，添加到选择结果
        /// 双击选择结果，移除双击项
        /// </summary>
        private void imgList_DoubleClick(object sender, EventArgs e)
        {
            ImageListBoxControl imgListBox = sender as ImageListBoxControl;
            MouseEventArgs mea = e as MouseEventArgs;
            if (imgListBox == null || mea == null) return;
            ListBoxItem listBoxItem = imgListBox.SelectedItem as ListBoxItem;
            if (listBoxItem == null) return;
            if (object.ReferenceEquals(imgListBox, imgListAll))
            {
                AddFromImgListAll();
            }
            else if (object.ReferenceEquals(imgListBox, imgListSelectResult))
            {
                RemoveCurSelect();
            }
        } 
        #endregion
    }
}
