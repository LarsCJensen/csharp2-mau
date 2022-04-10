using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class TakeOff : EventArgs
    {
        // Which properties??
        public string FlightCode { get; set; }
        public string Time { get; set; }
        public TakeOff()
        {
            // Status == "Started"
        }
    }
}
