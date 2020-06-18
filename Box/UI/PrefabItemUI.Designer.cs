namespace Box.UI
{
    partial class PrefabItemUI
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
            this.peMain = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.peMain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // peMain
            // 
            this.peMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peMain.Location = new System.Drawing.Point(1, 1);
            this.peMain.Name = "peMain";
            this.peMain.Size = new System.Drawing.Size(28, 28);
            this.peMain.TabIndex = 0;
            this.peMain.Click += new System.EventHandler(this.peMain_Click);
            // 
            // PrefabItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.peMain);
            this.Name = "PrefabItem";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(30, 30);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PrefabItem_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.peMain.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit peMain;

    }
}
