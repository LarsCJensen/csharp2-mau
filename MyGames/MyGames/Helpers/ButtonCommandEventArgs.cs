using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGames.Helpers
{
    /// <summary>
    /// Class to enable passing av EventArgs with commands
    /// </summary>
    public class ButtonCommandEventArgs: EventArgs
    {
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
