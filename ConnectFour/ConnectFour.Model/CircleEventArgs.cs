using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.Model
{
    public class CircleEventArgs : EventArgs
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Circle Circle { get; private set; }

        public CircleEventArgs(int x, int y, Circle circle)
        {
            X = x;
            Y = y;
            Circle = circle;
        }
    }
}
