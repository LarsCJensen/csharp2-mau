using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyGames.Dialogs.DialogService
{
    public abstract class DialogViewModelBase
    {
        public DialogResult UserDialogResult { get; private set; }
        public void CloseDialogWithResult(Window dialog, DialogResult result)
        {
            this.UserDialogResult = result;
            if(dialog != null)
            {
                dialog.DialogResult = true;
            }
        }
    }
}
