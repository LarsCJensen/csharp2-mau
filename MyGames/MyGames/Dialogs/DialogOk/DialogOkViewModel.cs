﻿using Microsoft.Toolkit.Mvvm.Input;
using MyGames.Dialogs.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyGames.Dialogs.DialogOk
{
    /// <summary>
    /// ViewModel for Dialog OK
    /// </summary>
    public class DialogOkViewModel: DialogViewModelBase
    {
        private RelayCommand<Window> _okCommand = null;
        public RelayCommand<Window> OkCommand
        {
            get { return _okCommand; }
            set { _okCommand = value; }
        }
        public DialogOkViewModel(string title, string message): base(title, message)
        {
            _okCommand = new RelayCommand<Window>(OnOkClicked);
        }
        private void OnOkClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.Ok);
        }
    }
}
