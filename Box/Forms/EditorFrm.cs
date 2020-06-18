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
    public partial class EditorFrm : Form
    {
        public EditorFrm()
        {
            InitializeComponent();
        }
        public EditorFrm(BoxGame boxGame)
            : this()
        {
            this.editorUI.BoxGame = boxGame;
        }

        private void tsmiUnion_Click(object sender, EventArgs e)
        {
            UnionEditFrm ueFrm = new UnionEditFrm();
            ueFrm.ShowDialog();
        }
    }
}