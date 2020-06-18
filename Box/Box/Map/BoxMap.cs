using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Game.Box
{
    /// <summary>
    /// 地图的层
    /// </summary>
    [Serializable]
    public class BoxMap : SerializableDictionary<Point, BoxItem>
    {
        public BoxItem this[int x, int y]
        {
            get
            {
                return this[new Point(x, y)];
            }
            set
            {
                this[new Point(x, y)] = value;
            }
        }
        public new BoxItem this[Point pos]
        {
            get
            {
                return base[pos];
            }
            set
            {
                base[pos] = value;
                if (ItemAddEventHandler != null) ItemAddEventHandler(this);
            }
        }
        public new void Add(Point pos, BoxItem item)
        {
            base.Add(pos, item);
            if (ItemAddEventHandler != null) ItemAddEventHandler(this);
        }
        private Action<BoxMap> ItemAddEventHandler;
        public new event Action<BoxMap> ItemAdd
        {
            add { this.ItemAddEventHandler += value; }
            remove { this.ItemAddEventHandler -= value; }
        }

    }
}
