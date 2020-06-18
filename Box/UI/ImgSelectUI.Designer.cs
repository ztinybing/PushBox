namespace Box.UI
{
    partial class ImgSelectUI
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
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.imgListSelectResult = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imgListSource = new System.Windows.Forms.ImageList(this.components);
            this.imgListAll = new DevExpress.XtraEditors.ImageListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSelectResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListAll)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(135, 113);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(39, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "→";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // imgListSelectResult
            // 
            this.imgListSelectResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgListSelectResult.ImageList = this.imgListSource;
            this.imgListSelectResult.Location = new System.Drawing.Point(180, 1);
            this.imgListSelectResult.Name = "imgListSelectResult";
            this.imgListSelectResult.Size = new System.Drawing.Size(132, 268);
            this.imgListSelectResult.TabIndex = 4;
            this.imgListSelectResult.DoubleClick += new System.EventHandler(this.imgList_DoubleClick);
            // 
            // imgListSource
            // 
            this.imgListSource.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListSource.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListSource.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgListAll
            // 
            this.imgListAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.imgListAll.ImageList = this.imgListSource;
            this.imgListAll.Location = new System.Drawing.Point(0, 1);
            this.imgListAll.Name = "imgListAll";
            this.imgListAll.Size = new System.Drawing.Size(129, 268);
            this.imgListAll.TabIndex = 3;
            this.imgListAll.DoubleClick += new System.EventHandler(this.imgList_DoubleClick);
            // 
            // ImgSelectUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.imgListSelectResult);
            this.Controls.Add(this.imgListAll);
            this.Name = "ImgSelectUI";
            this.Size = new System.Drawing.Size(313, 269);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSelectResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.ImageListBoxControl imgListSelectResult;
        private DevExpress.XtraEditors.ImageListBoxControl imgListAll;
        private System.Windows.Forms.ImageList imgListSource;
    }
}
