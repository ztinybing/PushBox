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
        /// 初始化方向计数字典
        /// </summary>
        private void InitDirectDict()
        {
            directCountDict[DirectionOptions.Up] = 0;
            directCountDict[DirectionOptions.Down] = 0;
            directCountDict[DirectionOptions.Left] = 0;
            directCountDict[DirectionOptions.Right] = 0;
        }
        //每次转换方向计时总次数
        const int turnDirectionCount = 4;
        //计时次数
        int curDirectionCount = 1;
        /// <summary>
        /// 当前方向
        /// </summary>
        DirectionOptions curDir = DirectionOptions.Down;
        void timer_Tick(object sender, EventArgs e)
        {
            //转换方向
            if (curDirectionCount >= turnDirectionCount)
            {
                curDir = RndDirection.NewRndDirection;
                curDirectionCount = 0;
            }
            //方向图片显示
            foreach (Control c in pcPrefab.Controls)
            {
                PrefabItemUI prefabItemUI = c as PrefabItemUI;
                if (prefabItemUI == null) continue;
                prefabItemUI.ShowDirection = curDir;
                prefabItemUI.ShowIndex = directCountDict[curDir];
            }
            //当前方向计次增加
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
        /// 初始化预置
        /// </summary>
        private void InitPrefab()
        {
            pcPrefab.Controls.Clear();
            //加载预置Box
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
            //"删除"功能Box
            BoxItem boxDeleteItem = new BoxItem("Delete");
            PrefabItemUI prefabDeleteItem = new PrefabItemUI(boxDeleteItem);
            prefabDeleteItem.Click += new EventHandler(prefabItem_Click);
            pcPrefab.Controls.Add(prefabDeleteItem);
            prefabDeleteItem.Location = new Point(PrefabList.Instance.CurPrefabList.Count * prefabDeleteItem.Width, 0);
            //"添加"功能Box
            BoxItem boxAddItem = new BoxItem("Add");
            PrefabItemUI prefabAddItem = new PrefabItemUI(boxAddItem);
            prefabAddItem.Click += new EventHandler(prefabAddItem_Click);
            pcPrefab.Controls.Add(prefabAddItem);
            prefabAddItem.Location = new Point((PrefabList.Instance.CurPrefabList.Count + 1) * prefabAddItem.Width, 0);
        }

        #region 事件处理函数
        private void EditorUI_HandleDestroyed(object sender, EventArgs e)
        {
            //保存预置
            PrefabList.Instance.SavePrefab();
        }

        private void EditorUI_Load(object sender, EventArgs e)
        {
            InitPrefab();//预置栏初始化
            InitLayer();//层选择
        }
        //初始化层选择
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
        /// 预置Box点击，设置选中状态、当前设计Box、属性显示
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
            prefabItem.IsSelected = true;//设置选中（红边框）
            showMapUI.DesignBoxItem = prefabItem.BoxItem;//设置当前设计Box
            biPropEdit.BoxItem = prefabItem.BoxItem;//属性显示
        }
        /// <summary>
        /// 预置Box添加项点击
        /// </summary>
        void prefabAddItem_Click(object sender, EventArgs e)
        {
            PrefabList.Instance.CurPrefabList.Add(new BoxItem());
            InitPrefab();
        }
        #endregion
        /// <summary>
        /// 保存设计
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            BoxGame.SaveToStage();
        }
        /// <summary>
        /// 是否显示所有层勾选切换
        /// </summary>
        private void ceAll_CheckedChanged(object sender, EventArgs e)
        {
            this.showMapUI.ShowAllLayer = ceAll.Checked;
        }
        /// <summary>
        /// 选择层改变
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
        /// 关卡改变
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
        /// 清除当前层
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
