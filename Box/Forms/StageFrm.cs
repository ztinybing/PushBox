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
    /// <summary>
    /// �ؿ�����
    /// </summary>
    public partial class StageFrm : Form
    {
        private Timer timer = new Timer();
        public StageFrm()
        {
            InitializeComponent();
            InitTimer();
        }

        private void InitTimer()
        {
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.boxGame.CharacterTimerCount++;
            this.showMapUI.Refresh();
        }
        private BoxGame boxGame = new BoxGame();
        private void StageFrm_Load(object sender, EventArgs e)
        {
            showMapUI.BoxGame = this.boxGame;
            //ע��ؿ�ѡ��ı��¼�
            cbStageSelect.SelectedIndexChanged += cbStageSelect_SelectedIndexChanged;
            this.boxGame.StageLoaded += new Action<uint>(boxGame_StageLoaded);
            InitExistStage();
        }

        void boxGame_StageLoaded(uint stage)
        {
            cbStageSelect.SelectedIndexChanged -= cbStageSelect_SelectedIndexChanged;
            cbStageSelect.SelectedItem = stage;
            cbStageSelect.SelectedIndexChanged += cbStageSelect_SelectedIndexChanged;
        }
        private void InitExistStage()
        {
            int curSelectedIndex = cbStageSelect.SelectedIndex;
            cbStageSelect.Items.Clear();
            //��Ӵ��ڹؿ���
            foreach (uint stage in this.boxGame.existStageList)
            {
                cbStageSelect.Items.Add(stage);
            }
            if (curSelectedIndex >= 0)
            {
                cbStageSelect.SelectedIndex = curSelectedIndex;//����ԭѡ��ؿ�
            }
            else if (cbStageSelect.SelectedIndex < 0 && this.boxGame.existStageList.Count > 0) cbStageSelect.SelectedIndex = 0;
        }
        /// <summary>
        /// �ؿ�ѡ��ı䣬���ض�Ӧ�ؿ�
        /// </summary>
        void cbStageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStageSelect.SelectedItem != null)
            {
                showMapUI.BoxGame.Stage = ((uint)cbStageSelect.SelectedItem);
                showMapUI.Refresh();
            }
        }
        /// <summary>
        /// ����ƴ���
        /// </summary>
        private void tsmDesign_Click(object sender, EventArgs e)
        {
            EditorFrm editorFrm = new EditorFrm(this.boxGame);
            editorFrm.Location = this.Location;
            this.Hide();
            editorFrm.ShowDialog();
            this.Show();
            InitExistStage();//���������³�ʼ���ؿ�ѡ��
        }

        private void StageFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    this.boxGame.Up();
                    break;
                case 'a':
                    this.boxGame.Left();
                    break;
                case 's':
                    this.boxGame.Down();
                    break;
                case 'd':
                    this.boxGame.Right();
                    break;
                default: return;
            }
            this.showMapUI.Refresh();
        }

    }
}