using GalaSoft.MvvmLight.Messaging;
using MyGames.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace MyGames.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        //#region EventHandlers
        //public event PropertyChangedEventHandler PropertyChanged;

        //#endregion
        
        public GameView()
        {
            InitializeComponent();
            // For Message pattern which I was trying. Not used
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            
            GameViewModel vm = new GameViewModel();
            this.DataContext = vm;
            // Bind to OnClose event
            vm.OnClose += OnClose;
        }
        /// <summary>
        /// Method for MessagePattern, is not used.
        /// </summary>
        /// <param name="msg"></param>
        //private void NotificationMessageReceived(NotificationMessage msg)
        //{
        //    if (msg.Notification == "Close")
        //    {
        //        this.Close();
        //    }
        //}
        /// <summary>
        /// Method to handle close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
