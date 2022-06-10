using Microsoft.Toolkit.Mvvm.Input;
using MyGames.Dialogs.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyGames.Dialogs.DialogYesNo
{
    public class DialogYesNoViewModel: DialogViewModelBase
    {
        private RelayCommand yesCommand = null;
        public RelayCommand YesCommand
        {
            get { return yesCommand; }
            set { yesCommand = value; }
        }

        private RelayCommand noCommand = null;
        public RelayCommand NoCommand
        {
            get { return noCommand; }
            set { noCommand = value; }
        }

        public DialogYesNoViewModel()
        {
            yesCommand = new RelayCommand(OnYesClicked);
            noCommand = new RelayCommand(OnNoClicked);
        }

        private void OnNoClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.No);
        }

        private void OnYesClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.Yes);
        }
    }
}
