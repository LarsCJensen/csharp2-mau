using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Toolkit.Mvvm.Input;
using MyGames.Models;

namespace MyGames.ViewModels
{
    public class GameViewModel: BaseViewModel, IDataErrorInfo
    {
        #region Properties
        private Game _game;
        public Game Game
        {
            get { return _game; }
            set { _game = value; }
        }
        private bool _editMode;
        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                // NotifyPropertyChanged
            }
        }
        private bool _detailsMode;
        public bool DetailsMode
        {
            get { return _detailsMode; }
            set { _detailsMode = value; }
        }
        private ObservableCollection<Platform> _platforms;
        public ObservableCollection<Platform> Platforms
        {
            get { return _platforms; }
            set { if(value != null)
                {
                    _platforms = value;
                    OnPropertyChanged("Platforms");
                }
            }
        }
        private ObservableCollection<Genre> _genres;
        public ObservableCollection<Genre> Genres
        {
            get { return _genres; }
            set
            {
                if (value != null)
                {
                    _genres = value;
                    OnPropertyChanged("Genres");
                }
            }
        }

        private Platform _selectedPlatform;
        public Platform SelectedPlatform
        {
            get { return _selectedPlatform; }
            set { if (value != null) 
                {
                    _selectedPlatform = value;
                }
            }
        }
        private List<int> _gradesList;
        public List<int> GradesList
        {
            get { return _gradesList; }
            set { _gradesList = value; }
        }        
        private List<int> _conditionList;
        public List<int> ConditionList
        {
            get { return _conditionList; }
            set { _conditionList = value; }
        }
        // For SQL Server
        //MyGamesContext _context = new MyGamesContext();
        MyGamesSQLServerCompactContext _context = new MyGamesSQLServerCompactContext();
        #endregion
        #region Commands
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CloseCommand { get; private set; }
        #endregion


        #region IDataErrorInfo
        public string Error => throw new NotImplementedException();
        
        public string this[string property]
        {
            get
            {
                string validationResult = String.Empty;
                switch (property)
                {
                    case "Title":
                        validationResult = ValidateTitle();
                        break;
                }
                return validationResult;
            }
        }
        #endregion
        #region Events
        // TODO??
        public event EventHandler GameSaved;
        #endregion

        public GameViewModel()
        {
            _game = new Game();
            _detailsMode = false;
            _editMode=true;
            SaveCommand = new RelayCommand(SaveGame);
            CloseCommand = new RelayCommand(Close);
            LoadPlatforms();
            LoadGenres();
            _gradesList = GetListOfIntValues(10);
            _conditionList = GetListOfIntValues(10);
        }
        
        public GameViewModel(Game game)
        {
            _game = game;
            SaveCommand = new RelayCommand(SaveGame);
        }
        
        private void SaveGame()
        {
            // TODO Validate ??
            // TODO Error handling
            //Genre genre = _context.Genres.FirstOrDefault(g => g.GenreId == _game.Genre.GenreId);
            
            _context.Games.Add(_game);
            _context.SaveChanges();
            Close();
        }

        private void Close()
        {            
            Messenger.Default.Send(new NotificationMessage("Close"));
        }
        private void LoadPlatforms()
        {
            // TODO  use _context??
            using (var db = new MyGamesSQLServerCompactContext())
            {
                // TODO Error handling
                List<Platform> platformsList = db.Platforms.ToList();
                List<Platform> sortedPlatforms = platformsList.OrderBy(o => o.PlatformShort).ToList();
                _platforms = new ObservableCollection<Platform>(sortedPlatforms);                
            }
        }

        private void LoadGenres()
        {
            // TODO  use _context??
            using (var db = new MyGamesSQLServerCompactContext())
            {
                // TODO Error handling
                List<Genre> genreList = db.Genres.ToList();
                List<Genre> sortedGenres = genreList.OrderBy(g => g.GenreName).ToList();
                _genres = new ObservableCollection<Genre>(sortedGenres);
            }
        }
        private List<int> GetListOfIntValues(int length, int startValue=1)
        {
            List<int> values = new List<int>();
            for(int i = startValue; i < length+startValue; i++)
            {
                values.Add(i);
            }
            return values;
        }
        
        // TODO REMOVE
        private string ValidateTitle()
        {
            return String.IsNullOrEmpty(_game.Title) ? "Title cannot be empty" : String.Empty;
        }
        


    }
}
