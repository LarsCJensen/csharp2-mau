using MyGames.Helpers;
using MyGames.ViewModels;
using System.Windows;

namespace MyGames.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel vm = new MainViewModel();
            this.DataContext = vm;
            vm.OpenAddEditGame += OnOpenAddEditGame;
            vm.OnClose += delegate { this.Close(); };
        }        
        /// <summary>
        /// Method to handle OpenAddEditGame events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenAddEditGame(object sender, ButtonCommandEventArgs e)
        {
            MainViewModel mVm = (MainViewModel)sender;
            GameViewModel viewModel = null;
            // Which ButtonCommand was sent?
            switch(e.ButtonCommand)
            {
                case "Open":
                    viewModel = new GameViewModel(mVm.SelectedGame, false, true);
                    break;
                case "Edit":
                    viewModel = new GameViewModel(mVm.SelectedGame, true, false);
                    break;
                case "Add":
                    viewModel = new GameViewModel();
                    break;
                default:
                    viewModel = new GameViewModel();
                    break;
            }            
            
            GameView gameView = new GameView();
            // Bind OnClose event
            viewModel.OnClose += delegate { gameView.Close(); };
            gameView.DataContext = viewModel;
            gameView.Show();
        }        
    }
}
