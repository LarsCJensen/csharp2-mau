using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Toolkit.Mvvm.Input;
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
        MyGamesContext _context = new MyGamesContext();
        public RelayCommand SaveCommand { get; private set; }
        #endregion

        public GameViewModel()
        {
            _game = new Game();
            _detailsMode = false;
            _editMode=true;
            SaveCommand = new RelayCommand(SaveGame);
        }
        
        public GameViewModel(Game game)
        {
            _game = game;
            SaveCommand = new RelayCommand(SaveGame);
        }
        
        private void SaveGame()
        {
            // Validate
            // Save with context.SaveChanges()
            _game.Genre = _context.Genres.First();
            _context.Games.Add(_game);
            _context.SaveChanges();
            // SEND MESSAGE TO CLOSE
            Messenger.Default.Send(new NotificationMessage("Close"));

        }

        // TODO REMOVE
        //public ICommand SaveCommand
        //{
        //    get
        //    {
        //        if(_saveCommand == null)
        //        {
        //            _saveCommand = new RelayCommand(param => this.Save(),
        //                param => this.CanSave);
        //        }
        //    }
        //}
        //public void Save()
        //{
        //    if(!_game.isValid)
        //    {
        //        throw new Exception();
        //    }
        //    if(this.IsNewGame)
        //    {
        //        _gameRepository.AddGame(_game);
        //    }
        //}

    }
}
