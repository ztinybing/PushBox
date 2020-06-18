using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Box
{
    [Serializable]
    public class BoxItem : BoxItemBase
    {
        private uint millisecond = 1000;
        //切换图片毫秒数
        public uint Millisecond
        {
            get { return millisecond; }
            set { millisecond = value; }
        }
        public BoxItem()
            : this("Default", false)
        {
        }
        public BoxItem(string defaultImg, bool canCross)
            : base()
        {
            this.CanCross = canCross;
            if (defaultImg != "Default")
            {
                this.DownImageList.Add(defaultImg);
            }
        }
        public BoxItem(string defaultImg)
            : this(defaultImg, false)
        {
        }

        private List<string> upImageList = new List<string>();
        public List<string> UpImageList
        {
            get { return upImageList; }
            set { upImageList = value; }
        }
        private List<string> downImageList = new List<string>();
        public List<string> DownImageList
        {
            get
            {
                if (downImageList.Count > 1 && downImageList[0] == "Default")
                {
                    downImageList.RemoveAt(0);
                }
                return downImageList;
            }
            set { downImageList = value; }
        }
        private List<string> leftImageList = new List<string>();
        public List<string> LeftImageList
        {
            get { return leftImageList; }
            set { leftImageList = value; }
        }
        private List<string> rightImageList = new List<string>();
        public List<string> RightImageList
        {
            get { return rightImageList; }
            set { rightImageList = value; }
        }
        public string DefaultImg
        {
            get
            {
                if (this.DownImageList.Count > 0) return this.DownImageList[0];
                return "Default";
            }
        }
        public string GetImgName(DirectionOptions dir, int index)
        {
            List<string> imageList = null;
            switch (dir)
            {
                case DirectionOptions.Up:
                    imageList = this.UpImageList;
                    break;
                case DirectionOptions.Down:
                    imageList = this.DownImageList;
                    break;
                case DirectionOptions.Left:
                    imageList = this.LeftImageList;
                    break;
                case DirectionOptions.Right:
                    imageList = this.RightImageList;
                    break;
                default: return this.DefaultImg;
            }
            //该方向图片数量为0，则显示默认图片
            if (imageList.Count <= 0) return this.DefaultImg;
            return imageList[index % imageList.Count];
        }

        public BoxItem Clone()
        {
            BoxItem boxItem = new BoxItem();
            boxItem.Millisecond = this.Millisecond;
            boxItem.CanCross = this.CanCross;
            boxItem.UpImageList = new List<string>(this.UpImageList);
            boxItem.DownImageList = new List<string>(this.DownImageList);
            boxItem.LeftImageList = new List<string>(this.LeftImageList);
            boxItem.RightImageList = new List<string>(this.RightImageList);
            return boxItem;
        }
    }
}
