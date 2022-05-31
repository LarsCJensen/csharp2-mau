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
        public RelayCommand<object> OpenWindowCommand { get; private set; }
        public event EventHandler OpenAddGame;
        public MainViewModel()
        {
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

            // SQL Server
            //using (var db = new MyGamesContext())
            using (var db = new MyGamesSQLServerCompactContext())
            {
                List<Game> allGames = db.Games.ToList();
                //    var genre = new Genre { GenreName = "TestGenre" };
                //    db.Genres.Add(genre);
                //    db.SaveChanges();
                //    var game = new Game { Title = "test", Genre = genre };
                //    db.Games.Add(game);
                //    db.SaveChanges();

                //    // Display all Blogs from the database
                //    var query = from b in db.Games
                //                orderby b.Title
                //                select b;

                foreach (Game game in allGames)
                {
                    _gamesList.Add(game);
                }

                //    //Game newGame = db.Games.First(g => g.Title == "test");
            }
        
            OpenWindowCommand = new RelayCommand<object>(param => this.OpenWindowExecute(param));
            
        }
        // TODO Delegate instead!
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "GameAddedOrUpdated")
            {
                // For SQL Server
                //using (var db = new MyGamesContext())
                RefreshGameList();
            }
        }        
        /// <summary>
        /// Method to handle command for OpenWindowExecute, which does different things based on state
        /// </summary>
        /// <param name="state">Command parameter object</param>
        private void OpenWindowExecute(object state)
        {
            string str = state as string;
            if(str == "Add")
            {
                // Using event handlers instead of message pattern
                //Messenger.Default.Send(new NotificationMessage("ShowAddGame"));
                if(OpenAddGame != null)
                {
                    // Execute event OpenAddGame
                    OpenAddGame(this, EventArgs.Empty);
                }                
            }            
        }

        private void RefreshGameList()
        {
            using (var db = new MyGamesSQLServerCompactContext())
            {
                // TODO Error handling
                _gamesList = new ObservableCollection<Game>(db.Games.ToList());                
            }
        }

    }
}
