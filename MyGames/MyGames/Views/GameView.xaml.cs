using GalaSoft.MvvmLight.Messaging;
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
            // TODO What to listen for?
            // Edit, Close?
            // TODO Replace with Event or leave??
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        // TODO Events instead?
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "Close")
            {
                this.Close();
            }
        }
    }
}
