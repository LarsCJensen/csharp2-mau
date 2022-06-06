using MyGames.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyGames.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using MyGames.Helpers;

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
            // Tried out message pattern, but using event handlers instead
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            MainViewModel vm = new MainViewModel();
            this.DataContext = vm;
            vm.OpenAddEditGame += OnOpenAddEditGame;
        }
        /// <summary>
        /// Function if message pattern is used
        /// </summary>
        /// <param name="msg"></param>
        //private void NotificationMessageReceived(NotificationMessage msg)
        //{
        //    if (msg.Notification == "ShowAddGame")
        //    {
        //        GameViewModel viewModel = new GameViewModel();
        //        GameView gameView = new GameView();
        //        gameView.DataContext = viewModel;
        //        gameView.Show();
        //    }
        //}
        private void OnOpenAddEditGame(object sender, ButtonCommandEventArgs e)
        {
            MainViewModel mVm = (MainViewModel)sender;
            // If no selected game, open Add new game
            GameViewModel viewModel = null;
            if (mVm.SelectedGame == null)
            {
                viewModel = new GameViewModel();
            } else
            {
                if(e.ButtonCommand == "Open")
                {
                    // TODO Better way?
                    viewModel = new GameViewModel(mVm.SelectedGame,false, true);
                } else if (e.ButtonCommand =="Edit")
                {
                    viewModel = new GameViewModel(mVm.SelectedGame, true, false);
                }
            }
            
            GameView gameView = new GameView();
            // TODO Ta bort??
            //viewModel.OnClose += OnClose;
            viewModel.OnClose += delegate { gameView.Close(); };
            gameView.DataContext = viewModel;
            gameView.Show();
        }
        // TODO Ta bort
        //private void OnClose(object sender, EventArgs e)
        //{
        //    var button = sender as Button;
        //    if(button == null)
        //    {
        //        return;
        //    }
        //    var win = Window.GetWindow(button);
        //    if (win == null)
        //    {
        //        return;
        //    }
        //    win.Close();
        //}
    }
}
