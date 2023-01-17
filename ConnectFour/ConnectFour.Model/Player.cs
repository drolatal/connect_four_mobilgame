using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.Model
{
    public class Player
    {
        public string Name { get; set; }
        public int CircleCount { get; set; }
        public int WinCount { get; set; }

        public Player(string Name) {
            this.Name = Name;
            CircleCount = 21;
            WinCount = 0;
        }

        public Player() { }
    }
}
