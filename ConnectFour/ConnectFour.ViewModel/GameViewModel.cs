using ConnectFour.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.ViewModel
{
    public class GameViewModel : BindingSource
    {
        private Game _model;
        private CircleViewModel[][] _board;

        private DelegateCommand _throwCircleCommand;

        public string PlayerOneName { get; set; } = "Player1";
        public string PlayerTwoName { get; set; } = "Player2";
        public CircleViewModel[][] Board 
        {
            get { return _board; }
            private set
            {
                if (value != _board) 
                {
                    _board = value;
                    OnPropertyChanged();
                }
            }
        }

        public DelegateCommand SetPlayerNameCommand { get; set; }
        public DelegateCommand NewGameCommand { get; set; }

        public GameViewModel(Game model) {
            _model = model;

            _model.StartEvent += _model_StartEvent;
            _model.POWinEvent += _model_POWinEvent;
            _model.PTWinEvent += _model_PTWinEvent;
            _model.CircleChangedEvent += _model_CircleChangedEvent;
            _model.BoardChangedEvent += _model_BoardChangedEvent;

            NewGameCommand = new DelegateCommand(Command_NewGame);
            _throwCircleCommand= new DelegateCommand(Command_ThrowCircle);
            SetPlayerNameCommand = new DelegateCommand(Command_SetPlayerName);
        }

        public EventHandler GameStartedEvent;

        private void Command_SetPlayerName(object param)
        {
            _model.PlayerOne.Name = PlayerOneName;
            _model.PlayerTwo.Name = PlayerTwoName;
        }

        private void Command_NewGame(object param) {
            _model.NewGame();
        }

        private void Command_ThrowCircle(object param)
        {
            if (param != null && param is CircleViewModel circle)
            {
                _model.ThrowCircle(circle.X, circle.Y);
            }
        }

        private void _model_BoardChangedEvent(object sender, EventArgs e)
        {
            CircleViewModel[][] board= new CircleViewModel[_model.Widht][];

            for (int i = 0; i < _model.Widht; i++) {
                board[i] = new CircleViewModel[_model.Height];
                for (int j = 0; j < _model.Height; j++)
                {
                    board[i][j] = new CircleViewModel(j,i,_model.GetCircle(j,i),_model.IsGameOver, _throwCircleCommand);
                }
            }
            Board = board;
        }

        private void _model_CircleChangedEvent(object sender, CircleEventArgs e)
        {
            if (sender != null && sender is Game model)
            {
                if (e.X < Board.Length && e.Y < Board[e.X].Length)
                {
                    Board[e.X][e.Y].Update(e.X, e.Y, e.Circle, _model.IsGameOver);
                }
                else {
                    _model_BoardChangedEvent(sender, e);
                }
            }
        }

        private void _model_PTWinEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _model_POWinEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _model_StartEvent(object sender, EventArgs e)
        {
            GameStartedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
