namespace Box.UI
{
    partial class EditorUI
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
            Game.Box.BoxGame boxGame1 = new Game.Box.BoxGame();
            this.sccLeftRight = new DevExpress.XtraEditors.SplitContainerControl();
            this.sccLeftUpDown = new DevExpress.XtraEditors.SplitContainerControl();
            this.pcPrefab = new System.Windows.Forms.Panel();
            this.sccRightUpDown = new DevExpress.XtraEditors.SplitContainerControl();
            this.pcProp = new DevExpress.XtraEditors.PanelControl();
            this.btnClearCurLayer = new DevExpress.XtraEditors.SimpleButton();
            this.ceAll = new DevExpress.XtraEditors.CheckEdit();
            this.cbbLayer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.seStage = new DevExpress.XtraEditors.SpinEdit();
            this.pcEidt = new DevExpress.XtraEditors.PanelControl();
            this.showMapUI = new Box.UI.ShowMapDesignUI();
            this.biPropEdit = new Box.UI.BoxItemPropEidtUI();
            ((System.ComponentModel.ISupportInitialize)(this.sccLeftRight)).BeginInit();
            this.sccLeftRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sccLeftUpDown)).BeginInit();
            this.sccLeftUpDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sccRightUpDown)).BeginInit();
            this.sccRightUpDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcProp)).BeginInit();
            this.pcProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbLayer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcEidt)).BeginInit();
            this.pcEidt.SuspendLayout();
            this.SuspendLayout();
            // 
            // sccLeftRight
            // 
            this.sccLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccLeftRight.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sccLeftRight.Location = new System.Drawing.Point(0, 0);
            this.sccLeftRight.Name = "sccLeftRight";
            this.sccLeftRight.Panel1.Controls.Add(this.sccLeftUpDown);
            this.sccLeftRight.Panel1.Text = "Panel1";
            this.sccLeftRight.Panel2.Controls.Add(this.sccRightUpDown);
            this.sccLeftRight.Panel2.Text = "Panel2";
            this.sccLeftRight.Size = new System.Drawing.Size(474, 345);
            this.sccLeftRight.SplitterPosition = 101;
            this.sccLeftRight.TabIndex = 0;
            this.sccLeftRight.Text = "splitContainerControl1";
            // 
            // sccLeftUpDown
            // 
            this.sccLeftUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccLeftUpDown.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sccLeftUpDown.Horizontal = false;
            this.sccLeftUpDown.Location = new System.Drawing.Point(0, 0);
            this.sccLeftUpDown.Name = "sccLeftUpDown";
            this.sccLeftUpDown.Panel1.Controls.Add(this.showMapUI);
            this.sccLeftUpDown.Panel1.Text = "Panel1";
            this.sccLeftUpDown.Panel2.Controls.Add(this.pcPrefab);
            this.sccLeftUpDown.Panel2.Text = "Panel2";
            this.sccLeftUpDown.Size = new System.Drawing.Size(363, 341);
            this.sccLeftUpDown.SplitterPosition = 52;
            this.sccLeftUpDown.TabIndex = 1;
            this.sccLeftUpDown.Text = "splitContainerControl2";
            // 
            // pcPrefab
            // 
            this.pcPrefab.AutoScroll = true;
            this.pcPrefab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcPrefab.Location = new System.Drawing.Point(0, 0);
            this.pcPrefab.Name = "pcPrefab";
            this.pcPrefab.Size = new System.Drawing.Size(359, 48);
            this.pcPrefab.TabIndex = 1;
            // 
            // sccRightUpDown
            // 
            this.sccRightUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccRightUpDown.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sccRightUpDown.Horizontal = false;
            this.sccRightUpDown.Location = new System.Drawing.Point(0, 0);
            this.sccRightUpDown.Name = "sccRightUpDown";
            this.sccRightUpDown.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sccRightUpDown.Panel1.Controls.Add(this.pcProp);
            this.sccRightUpDown.Panel1.Text = "Panel1";
            this.sccRightUpDown.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sccRightUpDown.Panel2.Controls.Add(this.pcEidt);
            this.sccRightUpDown.Panel2.Text = "Panel2";
            this.sccRightUpDown.Size = new System.Drawing.Size(97, 341);
            this.sccRightUpDown.SplitterPosition = 117;
            this.sccRightUpDown.TabIndex = 0;
            this.sccRightUpDown.Text = "splitContainerControl1";
            // 
            // pcProp
            // 
            this.pcProp.Controls.Add(this.btnClearCurLayer);
            this.pcProp.Controls.Add(this.ceAll);
            this.pcProp.Controls.Add(this.cbbLayer);
            this.pcProp.Controls.Add(this.btnSave);
            this.pcProp.Controls.Add(this.seStage);
            this.pcProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcProp.Location = new System.Drawing.Point(0, 0);
            this.pcProp.Name = "pcProp";
            this.pcProp.Size = new System.Drawing.Size(97, 218);
            this.pcProp.TabIndex = 0;
            // 
            // btnClearCurLayer
            // 
            this.btnClearCurLayer.Location = new System.Drawing.Point(9, 144);
            this.btnClearCurLayer.Name = "btnClearCurLayer";
            this.btnClearCurLayer.Size = new System.Drawing.Size(71, 23);
            this.btnClearCurLayer.TabIndex = 4;
            this.btnClearCurLayer.Text = "清除当前层";
            this.btnClearCurLayer.Click += new System.EventHandler(this.btnClearCurLayer_Click);
            // 
            // ceAll
            // 
            this.ceAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ceAll.EditValue = true;
            this.ceAll.Location = new System.Drawing.Point(7, 95);
            this.ceAll.Name = "ceAll";
            this.ceAll.Properties.Caption = "显示所有";
            this.ceAll.Size = new System.Drawing.Size(75, 19);
            this.ceAll.TabIndex = 3;
            this.ceAll.CheckedChanged += new System.EventHandler(this.ceAll_CheckedChanged);
            // 
            // cbbLayer
            // 
            this.cbbLayer.Location = new System.Drawing.Point(7, 67);
            this.cbbLayer.Name = "cbbLayer";
            this.cbbLayer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbLayer.Properties.DropDownRows = 10;
            this.cbbLayer.Size = new System.Drawing.Size(77, 21);
            this.cbbLayer.TabIndex = 2;
            this.cbbLayer.SelectedIndexChanged += new System.EventHandler(this.cbbLayer_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // seStage
            // 
            this.seStage.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seStage.Location = new System.Drawing.Point(5, 25);
            this.seStage.Name = "seStage";
            this.seStage.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.seStage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seStage.Properties.IsFloatValue = false;
            this.seStage.Properties.Mask.EditMask = "\\\\d+";
            this.seStage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.seStage.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.seStage.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seStage.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal;
            this.seStage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.seStage.Size = new System.Drawing.Size(78, 21);
            this.seStage.TabIndex = 0;
            this.seStage.EditValueChanged += new System.EventHandler(this.seStage_EditValueChanged);
            // 
            // pcEidt
            // 
            this.pcEidt.Controls.Add(this.biPropEdit);
            this.pcEidt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcEidt.Location = new System.Drawing.Point(0, 0);
            this.pcEidt.Name = "pcEidt";
            this.pcEidt.Size = new System.Drawing.Size(97, 117);
            this.pcEidt.TabIndex = 0;
            // 
            // showMapUI
            // 
            boxGame1.Stage = ((uint)(1u));
            this.showMapUI.BoxGame = boxGame1;
            this.showMapUI.DesignLayer = ((uint)(1u));
            this.showMapUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showMapUI.Location = new System.Drawing.Point(0, 0);
            this.showMapUI.Name = "showMapUI";
            this.showMapUI.ShowAllLayer = true;
            this.showMapUI.Size = new System.Drawing.Size(359, 279);
            this.showMapUI.TabIndex = 0;
            // 
            // biPropEdit
            // 
            this.biPropEdit.BoxItem = null;
            this.biPropEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biPropEdit.Location = new System.Drawing.Point(2, 2);
            this.biPropEdit.Name = "biPropEdit";
            this.biPropEdit.Size = new System.Drawing.Size(93, 113);
            this.biPropEdit.TabIndex = 0;
            // 
            // EditorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sccLeftRight);
            this.Name = "EditorUI";
            this.Size = new System.Drawing.Size(474, 345);
            this.Load += new System.EventHandler(this.EditorUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sccLeftRight)).EndInit();
            this.sccLeftRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccLeftUpDown)).EndInit();
            this.sccLeftUpDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccRightUpDown)).EndInit();
            this.sccRightUpDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcProp)).EndInit();
            this.pcProp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbLayer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcEidt)).EndInit();
            this.pcEidt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl sccLeftRight;
        private DevExpress.XtraEditors.SplitContainerControl sccLeftUpDown;
        private ShowMapDesignUI showMapUI;
        private DevExpress.XtraEditors.SplitContainerControl sccRightUpDown;
        private DevExpress.XtraEditors.PanelControl pcProp;
        private DevExpress.XtraEditors.PanelControl pcEidt;
        private BoxItemPropEidtUI biPropEdit;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SpinEdit seStage;
        private DevExpress.XtraEditors.ComboBoxEdit cbbLayer;
        private DevExpress.XtraEditors.CheckEdit ceAll;
        private DevExpress.XtraEditors.SimpleButton btnClearCurLayer;
        private System.Windows.Forms.Panel pcPrefab;
    }
}
