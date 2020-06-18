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
        #region ����
        public void SetResult()
        {
            this.imgNameList.Clear();
            foreach (ListBoxItem item in imgListSelectResult.Items)
            {
                imgNameList.Add(item.Value.ToString());
            }
        }
        /// <summary>
        /// ��ʼ�����б�ѡ��
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
        /// ��ʼ����ǰѡ��
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
        /// ��ӵ���ѡ�������ͼƬ���
        /// </summary>
        /// <param name="name">ͼƬ����</param>
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
        /// �ӱ�ѡ�ؼ���ӵ�ѡ�����ؼ�
        /// </summary>
        public void AddFromImgListAll()
        {
            string selectedName = (imgListAll.SelectedItem as ListBoxItem).Value.ToString();
            if (string.IsNullOrEmpty(selectedName)) return;//���ж��ظ���������ظ�������
            AddToImgListSelect(selectedName);
        }

        /// <summary>
        /// ��ѡ�����ؼ��Ƴ�������
        /// </summary>
        public void RemoveCurSelect()
        {
            int selectedIndex = imgListSelectResult.SelectedIndex;
            if (selectedIndex < 0) return;
            imgListSelectResult.Items.RemoveAt(selectedIndex);
        } 
        #endregion
        #region �¼�������
        /// <summary>
        /// �����ӣ����Ҽ�ͷ���� ��ѡ����ӵ�ѡ����
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.AddFromImgListAll();
        }
        /// <summary>
        /// ˫����ѡ���ӵ�ѡ����
        /// ˫��ѡ�������Ƴ�˫����
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
