using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.ViewModel
{
    public class MenuViewModel : BindingSource
    {

        public DelegateCommand MenuNewGameCommand { get; set; }

        public MenuViewModel()
        {
            MenuNewGameCommand = new DelegateCommand(Command_MenuNewGame);
        }

        public EventHandler MenuNewGameEvent;

        private void Command_MenuNewGame(object o)
        {
            MenuNewGameEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
