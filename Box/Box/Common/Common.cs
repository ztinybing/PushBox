using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Box
{
    public enum DirectionOptions
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
    public enum LayerOptions
    {
        Wall = 1,
        Floor = 2,
        Target = 3,
        Box = 4,
        Role = 5
    }
    public static class RndDirection
    {
        public static DirectionOptions NewRndDirection
        {
            get
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                return (DirectionOptions)rnd.Next(4);
            }
        }
    }
}
