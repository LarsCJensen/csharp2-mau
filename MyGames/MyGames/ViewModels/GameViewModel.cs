using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        #endregion

        public GameViewModel()
        {
            _game = new Game();
            _game.Title = "Test Game";
            _detailsMode = false;
            _editMode=true;
        }
        public GameViewModel(Game game)
        {
            _game = game;
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
