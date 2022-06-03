using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class GameViewModel: BaseViewModel
    {
        #region Properties
        private Game _game;
        public Game Game
        {
            get { return _game; }
            set { _game = value; }
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
        public RelayCommand ChooseImageCommand { get; private set; }
        public RelayCommand<object> BoxCheckedCommand { get; private set; }
        #endregion

        // TODO remove
        //#region IDataErrorInfo
        //public string Error => throw new NotImplementedException();

        //public string this[string property]
        //{
        //    get
        //    {
        //        string validationResult = String.Empty;
        //        switch (property)
        //        {
        //            case "Title":
        //                validationResult = ValidateTitle();
        //                break;
        //        }
        //        return validationResult;
        //    }
        //}
        //#endregion
        #region Events
        // TODO or keep message pattern??
        //public event EventHandler Close;
        #endregion
        #region Constructors
        public GameViewModel()
        {
            _game = new Game();
            EditMode = false;
            DetailsMode = true;
            SaveCommand = new RelayCommand(SaveGame);
            CloseCommand = new RelayCommand(Close);
            ChooseImageCommand = new RelayCommand(ChooseImage);
            BoxCheckedCommand = new RelayCommand<object>(param => BoxChecked(param));
            LoadPlatforms();
            LoadGenres();
            _gradesList = GetListOfIntValues(10);
            _conditionList = GetListOfIntValues(10);
        }
        
        public GameViewModel(Game game, bool edit=false)
        {
            _game = game;
            EditMode = edit;
            SaveCommand = new RelayCommand(SaveGame);
        }

        #endregion
        // TODO Or leave as message??
        //#region EventHandlers
        //public event EventHandler GameSaved;
        //#endregion
        #region Command methods
        private void SaveGame()
        {
            // TODO Error handling
            try
            {
                _context.Games.Add(_game);
                _context.SaveChanges();
                Messenger.Default.Send(new NotificationMessage("GameAddedOrUpdated"));
            }
            catch (Exception ex)
            {
                // respond to error
            }
            Close();
        }

        private void Close()
        {            
            // TODO Use event? Or keep for test??
            Messenger.Default.Send(new NotificationMessage("Close"));
        }
        // TODO Violates this MVVM?
        // https://www.c-sharpcorner.com/article/dialogs-in-wpf-mvvm/
        private void ChooseImage()
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.Filter = "BMP|*.bmp|JPG|*.jpg|PNG|*.png|All files (*.*)|*.*";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                // TODO Source is to be bound to property, not Game.Image
                // Game.Image is the file-path
                //imgAnimal.Source = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
                _game.Image = dialog.FileName;
            }
        }
        private void BoxChecked(object chkBox) 
        { 
            string checkBox = chkBox.ToString();
            switch (checkBox)
            {
                case "Box":
                    _game.Box = true;
                    break;
                case "Manual":
                    _game.Manual = true;
                    break;                
            }
        }
        #endregion
        #region Private methods
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
        //private void SetImageData(byte[] data)
        //{
        //    var source = new BitmapImage();
        //    source.BeginInit();
        //    source.StreamSource = new MemoryStream(data);
        //    source.EndInit();

        //    // use public setter
        //    Image = source;
        //}
        #endregion



    }
}
