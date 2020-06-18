using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Box
{
    interface IMoveable
    {
        bool Up();
        bool Down();
        bool Left();
        bool Right();
    }
}
