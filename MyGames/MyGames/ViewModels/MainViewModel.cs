using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
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
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
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
        private ICollectionView _gamesView;
        public ICollectionView GamesView
        {
            get { return _gamesView; }       
            set
            {
                _gamesView = value;
                OnPropertyChanged("GamesView");
                OnPropertyChanged("Count");
            }
        }
        public int Count {
            get 
            {
                return _gamesList.Count;
            } 
        }

        private Game _selectedGame;
        public Game SelectedGame
        {
            get { return _selectedGame; }
            set 
            {                 
                _selectedGame = value;
                OnPropertyChanged("SelectedGame");                
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

        #region Commands
        public RelayCommand OpenGameCommand { get; private set; }
        public RelayCommand AddGameCommand { get; private set; }
        public RelayCommand EditGameCommand { get; private set; }
        public RelayCommand DeleteGameCommand { get; private set; }
        public RelayCommand CloseCommand { get; private set; }
        public RelayCommand LoadTestData { get; private set; }
        public RelayCommand ExportCommand { get; private set; }
        public RelayCommand MouseDown { get; private set; }
        public RelayCommand<string> SortCommand { get; private set; }
        #endregion
        #region EventHandlers
        public event EventHandler<ButtonCommandEventArgs> OpenAddEditGame;
        public event EventHandler OnClose;
        #endregion
        #region Constructor
        public MainViewModel()
        {
            // Using message pattern for this event
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

            GamesList = GetGamesList();
            // Get default view for gamesView
            GamesView = CollectionViewSource.GetDefaultView(GamesList);
            // Bind filter to Search textbox
            GamesView.Filter = o => String.IsNullOrEmpty(SearchFilter) ? true : ((Game)o).Title.ToLower().Contains(SearchFilter.ToLower());
            // Commands
            OpenGameCommand = new RelayCommand(OpenGameExecute);
            AddGameCommand = new RelayCommand(AddGameExecute);
            EditGameCommand = new RelayCommand(EditGameExecute);
            DeleteGameCommand = new RelayCommand(DeleteGameExecute);
            LoadTestData = new RelayCommand(LoadTestDataExecute);
            CloseCommand = new RelayCommand(Close);
            ExportCommand = new RelayCommand(ExportExecute);
            MouseDown = new RelayCommand(MouseDownExecute);
            SortCommand = new RelayCommand<string>(param => SortCommandExecute(param));
        }
        #endregion
        /// <summary>
        /// Method to react to messages sent
        /// </summary>
        /// <param name="msg">Message being received</param>
        // Wanted to test this patter out, so for this event I don't have "regular"
        // EventHandler
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            // On GameAddedOrUpdated
            if (msg.Notification == "GameAddedOrUpdated")
            {
                // Refresh CollectionView
                RefreshView();
            }
        }
        #region CommandExecutors
        /// <summary>
        /// Command executor for command Add
        /// </summary>
        private void AddGameExecute()
        {
            if (OpenAddEditGame != null)
            {
                // Execute event OpenAddGame and pass in event arg
                OpenAddEditGame(this, new ButtonCommandEventArgs("Add"));
            }
        }
        /// <summary>
        /// Command executor for command Open
        /// </summary>
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
        /// <summary>
        /// Command executor for delete game
        /// </summary>
        private void DeleteGameExecute()
        {
            string message = "Are you sure you want to delete the entry?";
            Dialogs.DialogService.DialogViewModelBase vm = new Dialogs.DialogYesNo.DialogYesNoViewModel("Delete?", message);
            Dialogs.DialogService.DialogResult result = Dialogs.DialogService.DialogService.OpenDialog(vm);
            if(result == Dialogs.DialogService.DialogResult.Yes)
            {
                try
                {
                    using (var db = new MyGamesSQLServerCompactContext())
                    {
                        // Needs to be attached to the db context
                        // before it is removed
                        // Used to test exception
                        //db.Database.ExecuteSqlCommand("raiserror('Manual SQL exception', 16, 1)");
                        db.Games.Attach(SelectedGame);
                        db.Games.Remove(SelectedGame);
                        db.SaveChanges();
                    }
                }
                catch (SqlException exc)
                {
                    string errorMessage = $"Error: {exc.Message}\n{exc.InnerException}";
                    Dialogs.DialogService.DialogViewModelBase errorVM = new Dialogs.DialogOk.DialogOkViewModel("Could not delete!", errorMessage);
                    Dialogs.DialogService.DialogResult errorVMResult = Dialogs.DialogService.DialogService.OpenDialog(errorVM);
                }
                RefreshView();
            }
            
        }        
        private void Close()
        {
            if (OnClose != null)
            {
                OnClose(this, EventArgs.Empty);
            }
        }
        private void ExportExecute()
        {
            // FUTURE
            string message = "Export function not yet implemented!";
            Dialogs.DialogService.DialogViewModelBase vm = new Dialogs.DialogOk.DialogOkViewModel("Not implemented!", message);
            Dialogs.DialogService.DialogResult result = Dialogs.DialogService.DialogService.OpenDialog(vm);
        }
        // FUTURE
        private void MouseDownExecute()
        {
            SelectedGame = null;
        }
        /// <summary>
        /// Helper to sort by column header
        /// </summary>
        /// <param name="param">Command paramter with property to sort by</param>
        private void SortCommandExecute(string param)
        {
            SortDescription sort = new SortDescription(param, ListSortDirection.Ascending);
            // If property already in collection then reverse sort
            if (GamesView.SortDescriptions.Contains(sort))
            {
                sort = new SortDescription(param, ListSortDirection.Descending);
            } else
            {
                sort = new SortDescription(param, ListSortDirection.Ascending);
                if (GamesView.SortDescriptions.Contains(sort))
                {
                    sort = new SortDescription(param, ListSortDirection.Descending);
                }
            }
            // Clear previous sortings
            GamesView.SortDescriptions.Clear();
            GamesView.SortDescriptions.Add(sort);            
        }
        #endregion
        #region TestData
        /// <summary>
        /// Command to load test data
        /// </summary>
        private void LoadTestDataExecute()
        {
            try
            {
                using (var db = new MyGamesSQLServerCompactContext())
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
            }
            catch (SqlException exc)
            {
                string errorMessage = $"Error: {exc.Message}\n{exc.InnerException}";
                Dialogs.DialogService.DialogViewModelBase errorVM = new Dialogs.DialogOk.DialogOkViewModel("Error!", errorMessage);
                Dialogs.DialogService.DialogResult errorVMResult = Dialogs.DialogService.DialogService.OpenDialog(errorVM);
                return;
            }
            RefreshView();
        }
        #endregion

        /// <summary>
        /// Helper method to get games from DB
        /// </summary>
        private ObservableCollection<Game> GetGamesList()
        {
            try
            {
                // SQL Server
                //using (var db = new MyGamesContext())
                using (var db = new MyGamesSQLServerCompactContext())
                {
                    // Using public property for NotifyProperty
                    return new ObservableCollection<Game>(db.Games.Include("Genre").Include("Platform").ToList());
                }
            }            
            catch (SqlException exc)
            {
                string errorMessage = $"Error: {exc.Message}\n{exc.InnerException}";
                Dialogs.DialogService.DialogViewModelBase errorVM = new Dialogs.DialogOk.DialogOkViewModel("Could not get games!", errorMessage);
                Dialogs.DialogService.DialogResult errorVMResult = Dialogs.DialogService.DialogService.OpenDialog(errorVM);
            }
            return new ObservableCollection<Game>();
        }
        public void RefreshView()
        {
            GamesList = GetGamesList();
            // FUTURE Is there a better way?
            GamesView = CollectionViewSource.GetDefaultView(GamesList);
            GamesView.Filter = o => String.IsNullOrEmpty(SearchFilter) ? true : ((Game)o).Title.ToLower().Contains(SearchFilter.ToLower());
        }

    }
}

