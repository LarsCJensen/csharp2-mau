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
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "Close")
            {                
                Messenger.Default.Send(new NotificationMessage("GameAddedOrUpdated"));
                this.Close();
                
            }
        }
        // TODO Use delegates

        //public GameView(Game game, bool editGame=false)
        //{
        //    InitializeComponent();
        //    DataContext = this;
        //    Game = game;
        //    EditMode = editGame;
        //    InitializeGUI();
        //}
        //private void InitializeGUI()
        //{


        //}
    }
}
