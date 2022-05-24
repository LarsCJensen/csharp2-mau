using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
                NotifyPropertyChanged();
            }
        }
        public MainViewModel()
        {
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

            //    //Game newGame = db.Games.First(g => g.Title == "test");
            //}            
        }
        // TODO Is this to go here?
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
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
    }
}
