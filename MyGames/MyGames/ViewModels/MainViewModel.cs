using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MyGames.Helpers;
using MyGames.Models;
using MyGames.Views;

namespace MyGames.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Game> _gamesList = new ObservableCollection<Game>();
        public ObservableCollection<Game> GamesList
        {
            get
            {
                return _gamesList;
            }
            set
            {
                _gamesList = value;
                OnPropertyChanged("GamesList");
            }
        }

        private Game _selectedGame;
        public Game SelectedGame
        {
            get { return _selectedGame; }
            set { if(value != null)
                {
                    _selectedGame = value;
                    OnPropertyChanged("SelectedGame");
                } 
            }
        }

        // TODO SKa alla view models ha sin egen databas-context?
        #region EventHandlers
        public RelayCommand OpenGameCommand { get; private set; }
        public RelayCommand AddGameCommand { get; private set; }
        public event EventHandler<ButtonCommandEventArgs> OpenAddEditGame;        
        #endregion
        public MainViewModel()
        {
            // TODO Switch to events
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            
            LoadGameList();

            OpenGameCommand = new RelayCommand(this.OpenGameExecute);
            AddGameCommand = new RelayCommand(this.AddGameExecute);
        }
        // TODO Delegate instead??
        /// <summary>
        /// Method to react to messages
        /// </summary>
        /// <param name="msg"></param>
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "GameAddedOrUpdated")
            {
                // For SQL Server
                //using (var db = new MyGamesContext())
                LoadGameList();
            }
        }
        #region CommandExecutors
        private void AddGameExecute()
        {
            if (OpenAddEditGame != null)
            {
                // Execute event OpenAddGame
                OpenAddEditGame(this, ButtonCommandEventArgs.Empty);
            }
        }
        /// <summary>
        /// Method to handle command for OpenWindowExecute, which does different things based on state
        /// </summary>
        /// <param name="state">Command parameter object</param>
        private void OpenGameExecute()
        {
            if (OpenAddEditGame != null)
            {
                OpenAddEditGame(this, new ButtonCommandEventArgs("Open"));
            }
        }
        
            //Game game = obj as Game;
            //if(game != null)
            //{
            //    if (OpenAddGame != null)
            //    {
            //        // Execute event OpenAddGame
            //        OpenAddGame(this, EventArgs.Empty);
            //    }
            //}
            //else
            //{
            //    // Using event handlers instead of message pattern
            //    //Messenger.Default.Send(new NotificationMessage("ShowAddGame"));
            //    if (OpenAddGame != null)
            //    {
            //        // Execute event OpenAddGame
            //        OpenAddGame(this, EventArgs.Empty);
            //    }
            //}
            //string str = state as string;
            //if(str == "Add")
            //{
            //    // Using event handlers instead of message pattern
            //    //Messenger.Default.Send(new NotificationMessage("ShowAddGame"));
            //    if(OpenAddGame != null)
            //    {
            //        // Execute event OpenAddGame
            //        OpenAddGame(this, EventArgs.Empty);
            //    }                
            //}            
            //if(str == "Open")
            //{
            //    if (OpenAddGame != null)
            //    {
            //        // Execute event OpenAddGame
            //        OpenAddGame(this, EventArgs.Empty);
            //    }
            //}
        #endregion

        /// <summary>
        /// Helper method to load games from DB
        /// </summary>
        private void LoadGameList()
        {
            // SQL Server
            //using (var db = new MyGamesContext())
            using (var db = new MyGamesSQLServerCompactContext())
            {
                // TODO Error handling
                // Using public property for NotifyProperty
                GamesList = new ObservableCollection<Game>(db.Games.Include("Genre").Include("Platform").ToList());                
            }
        }

    }
}
