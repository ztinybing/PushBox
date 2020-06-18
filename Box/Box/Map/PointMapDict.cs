using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Game.Box
{
    internal class PointMapDictionary : Dictionary<Point, List<BoxItem>>
    {
        public new List<BoxItem> this[Point pos]
        {
            get
            {
                if (!this.ContainsKey(pos)) base[pos] = new List<BoxItem>();
                return base[pos];
            }
        }
    }
}
