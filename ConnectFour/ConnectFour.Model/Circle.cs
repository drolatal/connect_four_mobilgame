using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConnectFour.Model
{
    public class Circle
    {
        public bool IsWhite { get; private set; }
        public bool IsRed { get; private set; }
        public bool IsGreen { get; private set; }

        public Circle() {
            IsWhite= true;
            IsRed= false;
            IsGreen= false;
        }

        public void ChangeColor(bool onTurn)
        {
            if (onTurn) //player two
            {
                IsGreen = true;
                IsWhite = false;
            }
            else      //player one
            {
                IsRed = true;
                IsWhite = false;
            }
        }

        public bool AreSamePlayerColor(Circle c)
        {
            return (c.IsGreen && this.IsGreen) || (c.IsRed && this.IsRed);
        }
    }
}
