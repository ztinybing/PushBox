namespace Box.Forms
{
    partial class EditorFrm
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
            this.editorUI = new Box.UI.EditorUI();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiUnion = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorUI
            // 
            boxGame1.Stage = ((uint)(1u));
            this.editorUI.BoxGame = boxGame1;
            this.editorUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorUI.Location = new System.Drawing.Point(0, 24);
            this.editorUI.Name = "editorUI";
            this.editorUI.Size = new System.Drawing.Size(472, 326);
            this.editorUI.TabIndex = 1;
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUnion});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(472, 24);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiUnion
            // 
            this.tsmiUnion.Name = "tsmiUnion";
            this.tsmiUnion.Size = new System.Drawing.Size(89, 20);
            this.tsmiUnion.Text = "合成效果编辑";
            this.tsmiUnion.Click += new System.EventHandler(this.tsmiUnion_Click);
            // 
            // EditorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 350);
            this.Controls.Add(this.editorUI);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "EditorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EditorFrm";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Box.UI.EditorUI editorUI;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiUnion;
    }
}