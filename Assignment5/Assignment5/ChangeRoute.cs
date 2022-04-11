using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class ChangeRoute : EventArgs
    {
        // Which properties??
        public string FlightNumber { get; set; }
        public string FlightStatus { get; set; }
        public DateTime Timestamp { get; }
        public ChangeRoute(string flightNo, string status)
        {
            FlightNumber = flightNo;
            FlightStatus = status;
            Timestamp = DateTime.Now;
        }
    }
}
