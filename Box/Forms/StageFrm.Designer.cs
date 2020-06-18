namespace Box.Forms
{
    partial class StageFrm
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
            Game.Box.BoxGame boxGame1 = new Game.Box.BoxGame();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cbStageSelect = new System.Windows.Forms.ToolStripComboBox();
            this.tsmDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.showMapUI = new Box.UI.ShowMapUI();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbStageSelect,
            this.tsmDesign});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(325, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cbStageSelect
            // 
            this.cbStageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStageSelect.Name = "cbStageSelect";
            this.cbStageSelect.Size = new System.Drawing.Size(75, 20);
            // 
            // tsmDesign
            // 
            this.tsmDesign.Name = "tsmDesign";
            this.tsmDesign.Size = new System.Drawing.Size(41, 20);
            this.tsmDesign.Text = "设计";
            this.tsmDesign.Click += new System.EventHandler(this.tsmDesign_Click);
            // 
            // showMapUI
            // 
            boxGame1.Stage = ((uint)(1u));
            this.showMapUI.BoxGame = boxGame1;
            this.showMapUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showMapUI.Location = new System.Drawing.Point(0, 24);
            this.showMapUI.Name = "showMapUI";
            this.showMapUI.Size = new System.Drawing.Size(325, 294);
            this.showMapUI.TabIndex = 0;
            // 
            // StageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 318);
            this.Controls.Add(this.showMapUI);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StageFrm";
            this.ShowIcon = false;
            this.Text = "Box";
            this.Load += new System.EventHandler(this.StageFrm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StageFrm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Box.UI.ShowMapUI showMapUI;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox cbStageSelect;
        private System.Windows.Forms.ToolStripMenuItem tsmDesign;
    }
}