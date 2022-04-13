using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// Class for TakeOff
    /// </summary>
    public class TakeOff : EventArgs
    {
        public string FlightNumber { get; set; }
        public string FlightStatus { get; set; }
        public DateTime Timestamp { get; }
        public TakeOff(string flightNo)
        {
            FlightNumber = flightNo;
            FlightStatus = "Sent to runway";
            Timestamp = DateTime.Now;
        }
    }
}
