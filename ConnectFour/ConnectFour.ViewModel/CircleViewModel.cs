using ConnectFour.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConnectFour.ViewModel
{
    public enum CircleColor {WHITE, RED, GREEN }

    public class CircleViewModel : BindingSource
    {
        private CircleColor _color;

        internal int X { get; private set; }
        internal int Y { get; private set; }

        public CircleColor Color 
        {
            get => _color; 
            private set 
            { 
                if (_color != value) { 
                    _color = value; 
                    OnPropertyChanged();
                }
            }
        }

        public CircleViewModel()
        {

        }

        public CircleViewModel(int x, int y, Circle circle, bool isGameOver, DelegateCommand throwCircleCommand)
        {
            Update( x, y, circle,isGameOver);
            ThrowCircleCommand= throwCircleCommand;
        }

        public DelegateCommand ThrowCircleCommand { get; private set; }

        internal void Update(int x, int y, Circle circle, bool isGameOver) {
            X= x;
            Y= y;

            if (!isGameOver)
            {
                if (circle.IsGreen)
                {
                    Color = CircleColor.GREEN;
                }
                else if (circle.IsWhite)
                {
                    Color = CircleColor.WHITE;
                }
                else if (circle.IsRed)
                { 
                    Color= CircleColor.RED;
                }
            }
        }
    }
}
