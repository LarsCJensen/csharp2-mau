using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using MyGames.Models;

namespace MyGames.ViewModels
{
    /// <summary>
    /// Viewmodel for Games
    /// </summary>
    public class GameViewModel: BaseViewModel
    {
        #region Properties
        private Game _game;
        public Game Game
        {
            get { return _game; }
            set { 
                _game = value;
                OnPropertyChanged("Game");
            }
        }
        private BitmapImage _gameImage;
        public BitmapImage BitmapImage
        {
            get { return _gameImage; }
            set { 
                _gameImage = value; 
            }
        }
        
        private bool _editMode;
        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;
                OnPropertyChanged("EditMode");
            }
        }
        private bool _detailsMode;
        public bool DetailsMode
        {
            get { return _detailsMode; }
            set { 
                _detailsMode = value;
                OnPropertyChanged("DetailsMode");
            }
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
        public RelayCommand ChooseImageCommand { get; private set; }
        #endregion

        #region EventsHandlers
        public event EventHandler OnClose;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor for Add new game
        /// </summary>
        public GameViewModel()
        {
            _game = new Game();
            EditMode = true;
            DetailsMode = false;
            // Bind relay commands
            SaveCommand = new RelayCommand(SaveGame);
            CloseCommand = new RelayCommand(Close);
            ChooseImageCommand = new RelayCommand(ChooseImage);
            // Load comboboxes with data from database
            Platforms = new ObservableCollection<Platform>(GetPlatforms());
            Genres = new ObservableCollection<Genre>(GetGenres());
            // Load static comboboxes with numerical values
            _gradesList = GetListOfIntValues(10);
            _conditionList = GetListOfIntValues(10);
        }
        /// <summary>
        /// Constructor for edit or open game
        /// </summary>
        /// <param name="game">Game object</param>
        /// <param name="edit">If edit mode</param>
        /// <param name="details">If details mode</param> 
        // FUTURE Is multiple bools needed?
        public GameViewModel(Game game, bool edit=false, bool details=false)
        {
            if (edit)
            {
                Platforms = new ObservableCollection<Platform>(GetPlatforms());
                Genres = new ObservableCollection<Genre>(GetGenres()); 
                _gradesList = GetListOfIntValues(10);
                _conditionList = GetListOfIntValues(10);
                SaveCommand = new RelayCommand(SaveGame);                
                ChooseImageCommand = new RelayCommand(ChooseImage);
            }
            Game = game;
            EditMode = edit;
            DetailsMode = details;
            CloseCommand = new RelayCommand(Close);
            
        }
        #endregion
        #region Command methods        
        /// <summary>
        /// Method for SaveGame
        /// </summary>
        private void SaveGame()
        {
            // TODO Error handling
            try
            {
                using (var db = new MyGamesSQLServerCompactContext())
                {
                    db.Games.AddOrUpdate(_game);
                    db.SaveChanges();
                }
                // Testing Messenger to pass information about events, instead of EventHandler
                Messenger.Default.Send(new NotificationMessage("GameAddedOrUpdated"));
            }
            catch (Exception ex)
            {
                // respond to error
            }
            Close();
        }
        /// <summary>
        /// Method for Close command
        /// </summary>
        private void Close()
        {          
            if(OnClose != null)
            {
                OnClose(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Method to choose image from disk
        /// </summary>
        private void ChooseImage()
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG|*.jpg|BMP|*.bmp|PNG|*.png|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                _game.Image = dialog.FileName;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Helper to load platforms from database
        /// </summary>
        private List<Platform> GetPlatforms()
        {
            using (var db = new MyGamesSQLServerCompactContext())
            {
                // TODO Error handling
                List<Platform> platformsList = db.Platforms.ToList();
                List<Platform> sortedPlatforms = platformsList.OrderBy(o => o.PlatformShort).ToList();
                return sortedPlatforms;
            }
        }
        /// <summary>
        /// Helper to load genres from database
        /// </summary>
        private List<Genre> GetGenres()
        {
            using (var db = new MyGamesSQLServerCompactContext())
            {
                // TODO Error handling
                List<Genre> genreList = db.Genres.ToList();
                List<Genre> sortedGenres = genreList.OrderBy(g => g.GenreName).ToList();
                return sortedGenres;                
            }
        }
        /// <summary>
        /// Helper method to create list of ints
        /// </summary>
        /// <param name="length">Length of list</param>
        /// <param name="startValue">Which startvalue</param>
        /// <returns>List[int]</returns>
        private List<int> GetListOfIntValues(int length, int startValue=1)
        {
            List<int> values = new List<int>();
            for(int i = startValue; i < length+startValue; i++)
            {
                values.Add(i);
            }
            return values;
        }
        #endregion



    }
}
