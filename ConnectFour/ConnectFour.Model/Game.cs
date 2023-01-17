using System;
using System.IO;

namespace ConnectFour.Model
{
    public class Game
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public Circle[,] Board { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool OnTurn { get; private set; } //false -> playerone, true -> playertwo
        public int Widht { get; } = 7;
        public int Height { get; } = 6;

        public Game() {
            PlayerOne = new Player();
            PlayerTwo = new Player();
        }

        public event EventHandler StartEvent;
        public event EventHandler<CircleEventArgs> CircleChangedEvent;
        public event EventHandler BoardChangedEvent;
        public event EventHandler DrawEvent;
        public event EventHandler POWinEvent;
        public event EventHandler PTWinEvent;

        public void NewGame() {
            Board = new Circle[Height,Widht];
            for (int i = 0; i < 6; i++) {
                for (int j = 0; j < 7; j++) {
                    Board[i, j] = new Circle();
                }
            }
            IsGameOver = false;
            OnTurn = false;
            BoardChangedEvent?.Invoke(this, EventArgs.Empty);
            StartEvent?.Invoke(this, EventArgs.Empty);
        }

        public Circle GetCircle(int x, int y)
        {
            return Board[x, y];
        }

        private bool SearchHorizontal(int x,int y, Circle c) {
            int matchCount = 0;
            int i = 0;
            while (matchCount < 4 && i < 3) {
                matchCount = 0;
                int j = i;
                while(matchCount < 4 && j < 7 && Board[x,j].AreSamePlayerColor(c)){
                    matchCount++;
                    j++;
                }
                i++;
            }
            return matchCount == 4;
        }

        private bool SearchVertical(int x, int y, Circle c) {
            int matchCount = 0;
            int i = 0;
            while (matchCount < 4 && i < 2)
            {
                matchCount = 0;
                int j = i;
                while (matchCount < 4 && j < 6 && Board[j, y].AreSamePlayerColor(c))
                {
                    matchCount++;
                    j++;
                }
                i++;
            }
            return matchCount == 4;
        }

        private bool rightDiagonal(int x, int y, Circle c) 
        {
            int matchCount = 0;
            return matchCount == 4;
        }

        private bool leftDiagonal(int x, int y, Circle c)
        {
            int matchCount = 0;
            return matchCount == 4;
        }

        private bool SearchDiagonal(int x, int y, Circle c)
        {
            bool result = false;

            if (x + y > 2 && x + y < 9)
            {
                result = rightDiagonal(x,y,c);   //bal alsó sarokból jobb felső sarokba tartó egyenesek
            }

            if (x-y < 3 && x-y > -4)
            {
                result = leftDiagonal(x,y,c);   //bal felső sarokból a jobb alsó sarokba tartó egyenesek
            }
            return result;
        }

        public void SearchBoard(int x, int y, Circle c)
        {
            if (SearchHorizontal(x,y, c) || SearchVertical(x, y, c) || SearchDiagonal(x, y, c)) {
                IsGameOver= true;
            }
        }

        public void ThrowCircle(int x, int y)
        {
            if (!IsGameOver)
            {
                int i = x+1;
                while (i < Height && Board[i,y].IsWhite)
                { 
                    i++;
                }
                Board[i-1, y].ChangeColor(OnTurn);
                CircleChangedEvent?.Invoke(this, new CircleEventArgs(i-1,y,Board[i-1,y]));
                SearchBoard(i - 1, y, Board[i - 1, y]);
                if (!IsGameOver) {
                    OnTurn = !OnTurn;
                }
            }
        }
    }
}
