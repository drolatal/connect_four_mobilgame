using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConnectFour.ViewModel
{
    public class BindingSource : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
