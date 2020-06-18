using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Game.Box;

namespace Box.Forms
{
    public partial class UnionEditFrm : Form
    {
        public UnionEditFrm()
        {
            InitializeComponent();
            InitImages();
        }
        #region 函数
        private void InitImages()
        {
            for (int i = 0; i < UnionImgManager.Instance.Count; i++)
            {
                UnionItem item = UnionImgManager.Instance[i];
                imageList.Images.Add(GetImgByUnionItem(item));
                icbeSelect.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(i));
            }
        }

        private Image GetImgByUnionItem(UnionItem item)
        {
            int unitPixel = 12;
            int width = 0;
            int sourceCount = item.SourceList.Count <= 0 ? 1 : item.SourceList.Count;
            width += sourceCount * unitPixel;//源
            width += unitPixel;//箭头
            int unionResultCount = item.UnionResultList.Count <= 0 ? 1 : item.UnionResultList.Count;
            width += unionResultCount * unitPixel;//结果
            Bitmap img = new Bitmap(width, unitPixel);
            Graphics g = Graphics.FromImage(img);

            //源
            if (item.SourceList.Count <= 0) g.DrawString("无", this.Font, Brushes.Green, new RectangleF(0, 0, unitPixel, unitPixel));
            for (int i = 0; i < item.SourceList.Count; i++)
            {
                string source = item.SourceList[i];
                g.DrawImage(ImageManager.Instance[source], new Rectangle(unitPixel * i, 0, unitPixel, unitPixel), new Rectangle(0, 0, ImageManager.Instance[source].Width, ImageManager.Instance[source].Height), GraphicsUnit.Pixel);//, new Rectangle(i * unitPixel, 0, unitPixel, unitPixel), new Rectangle(0, 0, ImageManager.Instance[source].Width, ImageManager.Instance[source].Height), GraphicsUnit.Pixel);
            }
            
            //箭头
            g.DrawString("→", this.Font, Brushes.Blue, new RectangleF(sourceCount * unitPixel, 0, unitPixel, unitPixel));
            //结果
            if (item.UnionResultList.Count <= 0) g.DrawString("无", this.Font, Brushes.Green, new RectangleF((sourceCount + 1) * unitPixel, 0, unitPixel, unitPixel));
            for (int i = 0; i < item.UnionResultList.Count; i++)
            {
                string unionResult = item.UnionResultList[i];
                g.DrawImage(ImageManager.Instance[unionResult], new Rectangle((sourceCount + 1 + i) * unitPixel, 0, unitPixel, unitPixel));
            }
            return img;
        }

        private void RefreshImg()
        {
            if (icbeSelect.SelectedIndex < 0 || icbeSelect.SelectedIndex >= UnionImgManager.Instance.Count) return;
            UnionItem item = UnionImgManager.Instance[icbeSelect.SelectedIndex];
            pictureBox1.Image = GetImgByUnionItem(item);
            int index = icbeSelect.SelectedIndex;
            imageList.Images.RemoveAt(index);
            imageList.Images.Add(pictureBox1.Image);
            //imageList.Images[icbeSelect.SelectedIndex] = pictureBox1.Image;
        }
        #endregion

        #region 事件处理函数
        private void UnionEditFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnionImgManager.Instance.Save();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnionItem unionItem = UnionImgManager.Instance.AddNew();
            imageList.Images.Add(GetImgByUnionItem(unionItem));
            icbeSelect.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(imageList.Images.Count - 1));
        }

        private void icbeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (icbeSelect.SelectedIndex < 0 || icbeSelect.SelectedIndex >= UnionImgManager.Instance.Count) return;
            UnionItem item = UnionImgManager.Instance[icbeSelect.SelectedIndex];
            imgSelectSource.ImgNameList = item.SourceList;
            imgSelectResult.ImgNameList = item.UnionResultList;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            imgSelectSource.SetResult();
            imgSelectResult.SetResult();
            RefreshImg();
        }
        #endregion
    }
}