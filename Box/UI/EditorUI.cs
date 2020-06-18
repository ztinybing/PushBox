using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Game.Box;
using DevExpress.XtraEditors.Repository;
using Box.Forms;

namespace Box.UI
{
    public partial class EditorUI : UserControl
    {
        private Timer timer = new Timer();
        Dictionary<DirectionOptions, int> directCountDict = new Dictionary<DirectionOptions, int>();
        #region .ctor
        public EditorUI()
        {
            InitializeComponent();
            InitDirectDict();
            this.HandleDestroyed += new EventHandler(EditorUI_HandleDestroyed);
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
            pcPrefab.VerticalScroll.Visible = false;
        }

        public EditorUI(BoxGame boxGame)
            : this()
        {
            this.showMapUI.BoxGame = boxGame;
            this.seStage.Value = this.BoxGame.Stage;
        }
        #endregion
        /// <summary>
        /// ��ʼ����������ֵ�
        /// </summary>
        private void InitDirectDict()
        {
            directCountDict[DirectionOptions.Up] = 0;
            directCountDict[DirectionOptions.Down] = 0;
            directCountDict[DirectionOptions.Left] = 0;
            directCountDict[DirectionOptions.Right] = 0;
        }
        //ÿ��ת�������ʱ�ܴ���
        const int turnDirectionCount = 4;
        //��ʱ����
        int curDirectionCount = 1;
        /// <summary>
        /// ��ǰ����
        /// </summary>
        DirectionOptions curDir = DirectionOptions.Down;
        void timer_Tick(object sender, EventArgs e)
        {
            //ת������
            if (curDirectionCount >= turnDirectionCount)
            {
                curDir = RndDirection.NewRndDirection;
                curDirectionCount = 0;
            }
            //����ͼƬ��ʾ
            foreach (Control c in pcPrefab.Controls)
            {
                PrefabItemUI prefabItemUI = c as PrefabItemUI;
                if (prefabItemUI == null) continue;
                prefabItemUI.ShowDirection = curDir;
                prefabItemUI.ShowIndex = directCountDict[curDir];
            }
            //��ǰ����ƴ�����
            directCountDict[curDir]++;
            curDirectionCount++;
        }
        public BoxGame BoxGame
        {
            get { return this.showMapUI.BoxGame; }
            set
            {
                this.showMapUI.BoxGame = value;
                seStage.Value = value.Stage;
            }
        }

        /// <summary>
        /// ��ʼ��Ԥ��
        /// </summary>
        private void InitPrefab()
        {
            pcPrefab.Controls.Clear();
            //����Ԥ��Box
            for (int i = 0; i < PrefabList.Instance.CurPrefabList.Count; i++)
            {
                BoxItem boxItem = PrefabList.Instance.CurPrefabList[i];
                PrefabItemUI prefabItem = new PrefabItemUI(boxItem);
                if (object.ReferenceEquals(this.showMapUI.DesignBoxItem, boxItem))
                {
                    prefabItem.IsSelected = true;
                }
                prefabItem.Click += new EventHandler(prefabItem_Click);
                pcPrefab.Controls.Add(prefabItem);
                prefabItem.Location = new Point(prefabItem.Width * i, 0);
            }
            //"ɾ��"����Box
            BoxItem boxDeleteItem = new BoxItem("Delete");
            PrefabItemUI prefabDeleteItem = new PrefabItemUI(boxDeleteItem);
            prefabDeleteItem.Click += new EventHandler(prefabItem_Click);
            pcPrefab.Controls.Add(prefabDeleteItem);
            prefabDeleteItem.Location = new Point(PrefabList.Instance.CurPrefabList.Count * prefabDeleteItem.Width, 0);
            //"���"����Box
            BoxItem boxAddItem = new BoxItem("Add");
            PrefabItemUI prefabAddItem = new PrefabItemUI(boxAddItem);
            prefabAddItem.Click += new EventHandler(prefabAddItem_Click);
            pcPrefab.Controls.Add(prefabAddItem);
            prefabAddItem.Location = new Point((PrefabList.Instance.CurPrefabList.Count + 1) * prefabAddItem.Width, 0);
        }

        #region �¼�������
        private void EditorUI_HandleDestroyed(object sender, EventArgs e)
        {
            //����Ԥ��
            PrefabList.Instance.SavePrefab();
        }

        private void EditorUI_Load(object sender, EventArgs e)
        {
            InitPrefab();//Ԥ������ʼ��
            InitLayer();//��ѡ��
        }
        //��ʼ����ѡ��
        private void InitLayer()
        {
            cbbLayer.Properties.Items.Clear();
            for (int i = 1; i < 10; i++)
            {
                cbbLayer.Properties.Items.Add(i);
            }
            if (cbbLayer.Properties.Items.Count > 0 && cbbLayer.SelectedIndex < 0) cbbLayer.SelectedIndex = 0;
        }

        /// <summary>
        /// Ԥ��Box���������ѡ��״̬����ǰ���Box��������ʾ
        /// </summary>
        private void prefabItem_Click(object sender, EventArgs e)
        {
            PrefabItemUI prefabItem = sender as PrefabItemUI;
            if (prefabItem == null) return;
            foreach (Control c in pcPrefab.Controls)
            {
                if (c is PrefabItemUI)
                {
                    ((PrefabItemUI)c).IsSelected = false;
                }
            }
            prefabItem.IsSelected = true;//����ѡ�У���߿�
            showMapUI.DesignBoxItem = prefabItem.BoxItem;//���õ�ǰ���Box
            biPropEdit.BoxItem = prefabItem.BoxItem;//������ʾ
        }
        /// <summary>
        /// Ԥ��Box�������
        /// </summary>
        void prefabAddItem_Click(object sender, EventArgs e)
        {
            PrefabList.Instance.CurPrefabList.Add(new BoxItem());
            InitPrefab();
        }
        #endregion
        /// <summary>
        /// �������
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            BoxGame.SaveToStage();
        }
        /// <summary>
        /// �Ƿ���ʾ���в㹴ѡ�л�
        /// </summary>
        private void ceAll_CheckedChanged(object sender, EventArgs e)
        {
            this.showMapUI.ShowAllLayer = ceAll.Checked;
        }
        /// <summary>
        /// ѡ���ı�
        /// </summary>
        private void cbbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint tempLayer = 0;
            if (uint.TryParse(cbbLayer.SelectedText, out tempLayer))
            {
                this.showMapUI.DesignLayer = tempLayer;
            }
        }
        /// <summary>
        /// �ؿ��ı�
        /// </summary>
        private void seStage_EditValueChanged(object sender, EventArgs e)
        {
            uint tempStage = 0;
            if (uint.TryParse(seStage.Text, out tempStage))
            {
                this.BoxGame.ForceSetStage(tempStage);
                this.showMapUI.Refresh();
            }
        }
        /// <summary>
        /// �����ǰ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCurLayer_Click(object sender, EventArgs e)
        {
            uint tempLayer = 0;
            if (!uint.TryParse(cbbLayer.SelectedText, out tempLayer)) return;
            this.BoxGame.ClearLayer(tempLayer);
            this.showMapUI.Refresh();
        }
    }
}
