using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGames.Dialogs.DialogService
{
    public static class DialogService
    {
        public static DialogResult OpenDialog(DialogViewModelBase vm)
        {
            DialogWindow win = new DialogWindow();
            win.DataContext = vm;
            win.ShowDialog();
            return DialogResult.Undefined;
        }
    }
}
