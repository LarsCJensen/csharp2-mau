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

        // TODO SKa alla view models ha sin egen databas-context?
        public RelayCommand<object> OpenWindowCommand { get; private set; }
        public MainViewModel()
        {
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            using (var db = new MyGamesContext())
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

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "GameAddedOrUpdated")
            {
                using (var db = new MyGamesContext())
                {
                    List<Game> allGames = db.Games.ToList();
                    foreach (Game game in allGames)
                    {
                        _gamesList.Add(game);
                    }
                }
            }
        }
        // TODO Is this to go here?
        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        RelayCommand _saveCommand; public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    //_saveCommand = new RelayCommand(param => this.Save(),
                    //    param => this.CanSave);
                }
                return _saveCommand;
            }
        }

        RelayCommand _closeCommand; public ICommand CloseCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    //_saveCommand = new RelayCommand(param => this.Save(),
                    //    param => this.CanSave);
                }
                return _saveCommand;
            }
        }
        private void OpenWindowExecute(object state)
        {
            string str = state as string;
            if(str == "Add")
            {
                Messenger.Default.Send(new NotificationMessage("ShowAddGame"));
            }            
        }
    }
}
