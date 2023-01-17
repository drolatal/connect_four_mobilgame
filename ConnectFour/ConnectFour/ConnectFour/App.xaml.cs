using ConnectFour.Model;
using ConnectFour.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConnectFour
{
    public partial class App : Application
    {
        private Game _model;
        private GameViewModel _viewModel;
        private MenuViewModel _menuViewModel;

        private NavigationPage _rootPage;


        public App()
        {
            InitializeComponent();

            _model = new Game();
            _viewModel = new GameViewModel(_model);
            _viewModel.GameStartedEvent+= _model_StartEvent;
            _menuViewModel = new MenuViewModel();
            _menuViewModel.MenuNewGameEvent += _viewModel_menuNewGameButton_Clicked;

            MenuPage mp = new MenuPage();
            mp.MenuNewGameEvent += _viewModel_menuNewGameButton_Clicked;
            mp.BindingContext = _menuViewModel;

            _rootPage = new NavigationPage(mp);
            MainPage = _rootPage;
        }

        private async void _model_StartEvent(object sender, EventArgs e)
        {
            MainPage mp = new MainPage();
            mp.BindingContext = _viewModel;
            await _rootPage.Navigation.PushAsync(mp);
        }

        private async void _viewModel_menuNewGameButton_Clicked(object sender, EventArgs e)
        {
            DataPage dp = new DataPage();
            dp.BindingContext = _viewModel;
            await _rootPage.Navigation.PushAsync(dp);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
