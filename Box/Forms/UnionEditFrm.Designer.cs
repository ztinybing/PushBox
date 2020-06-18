namespace Box.Forms
{
    partial class UnionEditFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnionEditFrm));
            this.imgSelectSource = new Box.UI.ImgSelectUI();
            this.imgSelectResult = new Box.UI.ImgSelectUI();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.icbeSelect = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            ((System.ComponentModel.ISupportInitialize)(this.icbeSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgSelectSource
            // 
            this.imgSelectSource.ImgNameList = ((System.Collections.Generic.List<string>)(resources.GetObject("imgSelectSource.ImgNameList")));
            this.imgSelectSource.Location = new System.Drawing.Point(12, 78);
            this.imgSelectSource.Name = "imgSelectSource";
            this.imgSelectSource.Size = new System.Drawing.Size(321, 94);
            this.imgSelectSource.TabIndex = 0;
            // 
            // imgSelectResult
            // 
            this.imgSelectResult.ImgNameList = ((System.Collections.Generic.List<string>)(resources.GetObject("imgSelectResult.ImgNameList")));
            this.imgSelectResult.Location = new System.Drawing.Point(12, 212);
            this.imgSelectResult.Name = "imgSelectResult";
            this.imgSelectResult.Size = new System.Drawing.Size(321, 97);
            this.imgSelectResult.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "合成前选项";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 192);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "合成后选项";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(203, 192);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "合成后";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(203, 57);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "合成前";
            // 
            // icbeSelect
            // 
            this.icbeSelect.Location = new System.Drawing.Point(13, 13);
            this.icbeSelect.Name = "icbeSelect";
            this.icbeSelect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbeSelect.Properties.LargeImages = this.imageList;
            this.icbeSelect.Size = new System.Drawing.Size(236, 21);
            this.icbeSelect.TabIndex = 6;
            this.icbeSelect.SelectedIndexChanged += new System.EventHandler(this.icbeSelect_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(255, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(300, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(39, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "删除";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(280, 315);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(50, 23);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "应用";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(99, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 44);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.ImageList = this.imageList;
            this.dropDownButton1.Location = new System.Drawing.Point(62, 40);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(135, 23);
            this.dropDownButton1.TabIndex = 10;
            this.dropDownButton1.Text = "dropDownButton1";
            // 
            // UnionEditFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 338);
            this.Controls.Add(this.dropDownButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.icbeSelect);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.imgSelectResult);
            this.Controls.Add(this.imgSelectSource);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnionEditFrm";
            this.ShowIcon = false;
            this.Text = "合成编辑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UnionEditFrm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.icbeSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Box.UI.ImgSelectUI imgSelectSource;
        private Box.UI.ImgSelectUI imgSelectResult;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbeSelect;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
    }
}