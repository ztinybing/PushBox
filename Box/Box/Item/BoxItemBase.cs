using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;

namespace Game.Box
{
    [Serializable]
    public abstract class BoxItemBase
    {
        bool canCross = false;
        public bool CanCross
        {
            get { return canCross; }
            set { canCross = value; }
        }
        public BoxItemBase()
            : this(false)
        {
            
        }
        public BoxItemBase(bool canCross)
        {
            this.canCross = canCross;
        }


    }
}
