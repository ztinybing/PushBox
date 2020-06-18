using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Game.Box;

namespace Box.UI
{
    public partial class ShowMapUI : UserControl
    {
        public ShowMapUI()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//˫���棬����˸
        }
        public ShowMapUI(BoxGame boxGame)
            : this()
        {
            this.boxGame = boxGame;
        }
        protected BoxGame boxGame = null;
        public BoxGame BoxGame
        {
            get
            {
                if (this.boxGame == null) this.boxGame = new BoxGame();
                return this.boxGame;
            }
            set
            {
                this.boxGame = value;
            }
        }

        /// <summary>
        /// ��߾����
        /// </summary>
        public int BorderUnit = 1;
        protected int unit = 10;
        /// <summary>
        /// ÿ�����ӵ�λ����
        /// </summary>
        public int Unit
        {
            get { return unit; }
        }

        #region �¼�������
        /// <summary>
        /// �ڷǱ༭ģʽ����ؼ���Сʱ��������ӳ���
        /// </summary>
        protected virtual void ShowMapUI_Resize(object sender, EventArgs e)
        {
            //todo
        }
        protected virtual void ShowLayerEdit(List<uint> layerList)
        {
            //��ʾ���в�
            layerList.AddRange(BoxGame.LayerMapDict.Keys);
        }
        /// <summary>
        /// ���Ʊ�����ǰ�����ƶ���
        /// </summary>
        protected virtual void ShowMapUI_Paint(object sender, PaintEventArgs e)
        {
            if (BoxGame == null) return;
            List<uint> layerList = new List<uint>();
            ShowLayerEdit(layerList);
            layerList.Sort();//�����������ʾ
            //��ʾ���������
            foreach (uint layer in layerList)
            {
                foreach (KeyValuePair<Point, BoxItem> item in BoxGame.LayerMapDict[layer])
                {
                    BoxItem bbItem = item.Value;
                    if (item.Value == null) continue;
                    Rectangle rectangle = new Rectangle(item.Key.X * unit + BorderUnit, item.Key.Y * unit + BorderUnit, unit, unit);
                    if (layer == (uint)LayerOptions.Role)
                    {
                        e.Graphics.DrawImage(ImageManager.Instance[bbItem.GetImgName(this.boxGame.CharacterDirection, this.boxGame.CharacterTimerCount)], rectangle);
                    }
                    else
                    {
                        e.Graphics.DrawImage(ImageManager.Instance[bbItem.DefaultImg], rectangle);
                    }
                }
            }
        }
        #endregion
    }

}
