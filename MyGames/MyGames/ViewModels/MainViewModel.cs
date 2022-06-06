using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
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
        // TODO COlllection COunt!
        private ICollectionView _gamesView;
        public ICollectionView GamesView
        {
            get { return _gamesView; }       
            set
            {
                _gamesView = value;
                OnPropertyChanged("GamesView");
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
        private string _searchFilter;
        public string SearchFilter
        {
            get { return _searchFilter; }
            set 
            {
                _searchFilter = value;

                _gamesView.Refresh();
                OnPropertyChanged("SearchFilter");
            }
        }

        // TODO SKa alla view models ha sin egen databas-context?
        #region Commands
        public RelayCommand OpenGameCommand { get; private set; }
        public RelayCommand AddGameCommand { get; private set; }
        public RelayCommand EditGameCommand { get; private set; }
        public RelayCommand DeleteGameCommand { get; private set; }
        public RelayCommand LoadTestData { get; private set; }
        #endregion
        #region EventHandlers
        public event EventHandler<ButtonCommandEventArgs> OpenAddEditGame;        
        #endregion
        public MainViewModel()
        {
            // TODO Switch to events
            // Is this used??
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

            GamesList = GetGamesList();
            // Get default view for gamesView
            _gamesView = CollectionViewSource.GetDefaultView(GamesList);
            //TODO Starts with eller contains?
            // Bind filter to Search textbox
            _gamesView.Filter = o => String.IsNullOrEmpty(SearchFilter) ? true : ((Game)o).Title.Contains(SearchFilter);
            // Commands
            OpenGameCommand = new RelayCommand(this.OpenGameExecute);
            AddGameCommand = new RelayCommand(this.AddGameExecute);
            EditGameCommand = new RelayCommand(this.EditGameExecute);
            DeleteGameCommand = new RelayCommand(this.DeleteGameExecute);
            LoadTestData = new RelayCommand(this.LoadTestDataExecute);
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
                GamesList = GetGamesList();                
                GamesView = CollectionViewSource.GetDefaultView(GamesList);                
                GamesView.Filter = o => String.IsNullOrEmpty(SearchFilter) ? true : ((Game)o).Title.Contains(SearchFilter);
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
        private void EditGameExecute()
        {
            if (OpenAddEditGame != null)
            {
                OpenAddEditGame(this, new ButtonCommandEventArgs("Edit"));
            }
        }

        private void DeleteGameExecute()
        {
            // TODO Just delete game
            using (var db = new MyGamesSQLServerCompactContext())
            {
                // TODO Error handling
                // Using public property for NotifyProperty
                db.Games.Attach(SelectedGame);
                db.Games.Remove(SelectedGame);
                db.SaveChanges();
            }
            //using(_gamesView.DeferRefresh())
            //{
            //    GamesList = GetGamesList();                
            //}
            //_gamesView.Refresh();
            GamesList = GetGamesList();
            // TODO Is there a better way?
            GamesView = CollectionViewSource.GetDefaultView(GamesList);
            GamesView.Filter = o => String.IsNullOrEmpty(SearchFilter) ? true : ((Game)o).Title.Contains(SearchFilter);
            //GamesView.Refresh();

        }
        private void LoadTestDataExecute()
        {
            using(var db = new MyGamesSQLServerCompactContext())
            {
                var platform_pc = db.Platforms.Where(p => p.PlatformShort.Equals("PC")).FirstOrDefault();
                var platform_smd = db.Platforms.Where(p => p.PlatformShort.Equals("SMD")).FirstOrDefault();
                var platform_nes = db.Platforms.Where(p => p.PlatformShort.Equals("NES")).FirstOrDefault();
                var platform_a2600 = db.Platforms.Where(p => p.PlatformShort.Equals("Atari 2600")).FirstOrDefault();
                var platform_snes = db.Platforms.Where(p => p.PlatformShort.Equals("SNES")).FirstOrDefault();

                var genre_adv = db.Genres.Where(g => g.GenreName.Equals("Adventure")).FirstOrDefault();
                var genre_rpg = db.Genres.Where(g => g.GenreName.Equals("RPG")).FirstOrDefault();
                var genre_plat = db.Genres.Where(g => g.GenreName.Equals("Platform")).FirstOrDefault();
                var genre_act = db.Genres.Where(g => g.GenreName.Equals("Action")).FirstOrDefault();
                var genre_race = db.Genres.Where(g => g.GenreName.Equals("Racing")).FirstOrDefault();

                Game game = new Game();
                game.Title = "Quest for Glory: So you want to be a Hero";                
                game.GenreId = genre_adv.GenreId;
                game.PlatformId = platform_pc.PlatformId;
                game.ReleaseDate = DateTime.Parse("1993-01-01");
                game.Condition = 10;
                game.Box = true;
                game.Manual = true;
                game.Grade = 10;
                game.Region = "N/A";
                game.Comment = "Unopened";
                game.Image = "/assets/qfg_pc.jpg";
                db.Games.Add(game);

                game = new Game();
                game.Title = "Sam & Max: Hit the Road";
                game.GenreId = genre_adv.GenreId;
                game.PlatformId = platform_pc.PlatformId;
                game.ReleaseDate = DateTime.Parse("1993-01-01");
                game.Condition = 9;
                game.Box = true;
                game.Manual = true;
                game.Grade = 8;
                game.Region = "N/A";
                game.Comment = "Includes official hitbook";
                game.Image = "/assets/sam_n_max_pc.jpg";
                db.Games.Add(game);

                game = new Game();
                game.Title = "Shining Force";
                game.GenreId = genre_rpg.GenreId;
                game.PlatformId = platform_smd.PlatformId;
                game.ReleaseDate = DateTime.Parse("1993-01-01");
                game.Condition = 9;
                game.Box = true;
                game.Manual = true;
                game.Grade = 9;
                game.Region = "PAL";
                game.Comment = "Includes official hitbook";
                game.Image = "/assets/shining_force_smd.jpg";
                db.Games.Add(game);

                game = new Game();
                game.Title = "Super Mario Bros.";
                game.GenreId = genre_plat.GenreId;
                game.PlatformId = platform_nes.PlatformId;
                game.ReleaseDate = DateTime.Parse("1985-10-01");
                game.Condition = 9;
                game.Box = false;
                game.Manual = false;
                game.Grade = 9;
                game.Region = "NTSC-US";
                game.Comment = "Also have bundled with Duck Hunt";
                game.Image = "/assets/smb_nes.jpg";
                db.Games.Add(game);

                game = new Game();
                game.Title = "Solaris";
                game.GenreId = genre_act.GenreId;
                game.PlatformId = platform_a2600.PlatformId;
                game.ReleaseDate = DateTime.Parse("1986-01-01");
                game.Condition = 6;
                game.Box = true;
                game.Manual = true;
                game.Grade = null;
                game.Region = "PAL";
                game.Comment = "Box has wear and tape at the bottom";
                game.Image = "/assets/solaris_2600.jpg";
                db.Games.Add(game);

                game = new Game();
                game.Title = "Stonekeep";
                game.GenreId = genre_rpg.GenreId;
                game.PlatformId = platform_pc.PlatformId;
                game.ReleaseDate = DateTime.Parse("1986-01-01");
                game.Condition = 9;
                game.Box = true;
                game.Manual = true;
                game.Grade = 8;
                game.Region = "N/A";
                game.Comment = "Requires patch";
                game.Image = "/assets/stonekeep_pc.jpg";
                db.Games.Add(game);

                game = new Game();
                game.Title = "Super Mario Kart";
                game.GenreId = genre_race.GenreId;
                game.PlatformId = platform_snes.PlatformId;
                game.ReleaseDate = DateTime.Parse("1992-09-01");
                game.Condition = 9;
                game.Box = true;
                game.Manual = true;
                game.Grade = null;
                game.Region = "NTSC-US";
                game.Comment = "Mint condition";
                game.Image = "/assets/super_mario_kart_snes.jpg";
                db.Games.Add(game);

                db.SaveChanges();
            }
            GamesList = GetGamesList();
            GamesView = CollectionViewSource.GetDefaultView(GamesList);
            GamesView.Filter = o => String.IsNullOrEmpty(SearchFilter) ? true : ((Game)o).Title.Contains(SearchFilter);
        }
        #endregion

        /// <summary>
        /// Helper method to get games from DB
        /// </summary>
        private ObservableCollection<Game> GetGamesList()
        {
            // SQL Server
            //using (var db = new MyGamesContext())
            using (var db = new MyGamesSQLServerCompactContext())
            {
                // TODO Error handling
                // Using public property for NotifyProperty
                return new ObservableCollection<Game>(db.Games.Include("Genre").Include("Platform").ToList());                
            }
        }
        

    }
}

