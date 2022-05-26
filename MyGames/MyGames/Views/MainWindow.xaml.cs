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
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ShowAddGame")
            {
                GameViewModel viewModel = new GameViewModel();
                GameView gameView = new GameView();
                gameView.DataContext = viewModel;
                gameView.Show();
            }
        }

        //private void btnAddGame_Click(object sender, RoutedEventArgs e)
        //{
        //    GameView addNewGame = new GameView();
        //    if(addNewGame.ShowDialog() == true)
        //    {

        //    } else
        //    {
        //        // Cancel was clicked
        //    }
        //}
    }
}
