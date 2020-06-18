using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Game.Box;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace Box.UI
{
    public partial class ImageSelecedFrm : Form
    {
        public ImageSelecedFrm()
        {
            InitializeComponent();
        }
        public ImageSelecedFrm(List<string> imgNameList)
            : this()
        {
            this.imgSelectUI.ImgNameList = imgNameList;
        }


        #region �¼�������
        private void btnEditAll_Click(object sender, EventArgs e)
        {
            //imgListSource
        }
        /// <summary>
        /// ɾ��ѡ����������
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.imgSelectUI.RemoveCurSelect();
        }
        /// <summary>
        /// ����رգ�����ѡ�н����imgNameList
        /// </summary>
        private void ImageSelecedFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.imgSelectUI.SetResult();
        }
        #endregion
    }
}
