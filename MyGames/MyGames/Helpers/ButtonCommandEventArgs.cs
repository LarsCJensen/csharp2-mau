using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGames.Helpers
{
    public class ButtonCommandEventArgs: EventArgs
    {
        public static readonly ButtonCommandEventArgs Empty;
        private string _buttonCommand;
        public string ButtonCommand
        {
            get { return _buttonCommand; }
        }
        public ButtonCommandEventArgs(string command)
        {
            _buttonCommand = command;
        }
    }
}
