namespace Box.UI
{
    partial class ImageSelecedFrm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSelecedFrm));
            this.imgListSource = new System.Windows.Forms.ImageList(this.components);
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditAll = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.imgSelectUI = new Box.UI.ImgSelectUI();
            this.SuspendLayout();
            // 
            // imgListSource
            // 
            this.imgListSource.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListSource.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListSource.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRemove.Location = new System.Drawing.Point(232, 304);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(40, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "删除";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEditAll
            // 
            this.btnEditAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEditAll.Location = new System.Drawing.Point(41, 304);
            this.btnEditAll.Name = "btnEditAll";
            this.btnEditAll.Size = new System.Drawing.Size(40, 23);
            this.btnEditAll.TabIndex = 3;
            this.btnEditAll.Text = "编辑";
            this.btnEditAll.Click += new System.EventHandler(this.btnEditAll_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl1.Location = new System.Drawing.Point(25, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "备选项";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl2.Location = new System.Drawing.Point(224, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "选择结果";
            // 
            // imgSelectUI
            // 
            this.imgSelectUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.imgSelectUI.ImgNameList = ((System.Collections.Generic.List<string>)(resources.GetObject("imgSelectUI.ImgNameList")));
            this.imgSelectUI.Location = new System.Drawing.Point(1, 29);
            this.imgSelectUI.Name = "imgSelectUI";
            this.imgSelectUI.Size = new System.Drawing.Size(313, 269);
            this.imgSelectUI.TabIndex = 5;
            // 
            // ImageSelecedFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 330);
            this.Controls.Add(this.imgSelectUI);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnEditAll);
            this.Controls.Add(this.btnRemove);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageSelecedFrm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图片选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageSelecedFrm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private System.Windows.Forms.ImageList imgListSource;
        private DevExpress.XtraEditors.SimpleButton btnEditAll;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private ImgSelectUI imgSelectUI;
    }
}
