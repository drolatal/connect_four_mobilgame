using ConnectFour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConnectFour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {

        public MenuPage()
        {
            InitializeComponent();
        }

        public EventHandler MenuNewGameEvent;

        public void _NewGameButton_Clicked(object sender, EventArgs e) {
            MenuNewGameEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}