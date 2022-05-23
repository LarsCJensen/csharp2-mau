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
using MyGames.Model;

namespace MyGames.ViewModel
{
    public class MainViewModel: BaseViewModel
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
                base.OnPropertyChanged("GamesList");
            }
        }
        private Game _selectedGame;
        public Game SelectedGame { 
            get
            {
                return _selectedGame;
            } 
            
            set
            {
                if(value != null)
                {
                    _selectedGame = value;
                    base.OnPropertyChanged("SelectedGame");
                    this.IsGameDetailsShown = true;
                } else
                {
                    _isGameDetailsShown = false;
                }                
            }
                
        }
        private bool _isGameDetailsShown = false;
        public bool IsGameDetailsShown 
        { 
            get
            {
                return _isGameDetailsShown;
            }
            set
            {
                _isGameDetailsShown = value;
                base.OnPropertyChanged("IsGameDetailsShown");
            }
        }
        public MainViewModel()
        {
            AddCommand = new CommandRelay(o => AddGameClick("btnAddGame"));
            //using (var db = new MyGamesContext())
            //{
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

            //    foreach (var item in query)
            //    {                    
            //        _gamesList.Add(item);
            //    }

                //Game newGame = db.Games.First(g => g.Title == "test");
            //}            
        }
        private void AddGameClick(object sender)
        {
            MessageBox.Show(sender.ToString());
        }
        // TODO Is this to go here?
        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    if (base.OnPropertyChanged != null)
        //    {
        //        base.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        //CommandRelay _saveCommand; public ICommand SaveCommand
        //{
        //    get
        //    {
        //        if (_saveCommand == null)
        //        {
        //            _saveCommand = new CommandRelay(param => this.Save(),
        //                param => this.CanSave);
        //        }
        //        return _saveCommand;
        //    }
        //}

        CommandRelay _closeCommand; public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new CommandRelay(param => this.Close());
                }
                return _closeCommand;
            }
        }
        private void Close()
        {
            MessageBox.Show("Closing");            
        }        
    }
}
