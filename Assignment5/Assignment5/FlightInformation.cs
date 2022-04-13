using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// Class for FlightInformation
    /// </summary>
    public class FlightInformation
    {
        public string FlightNumber { get; set; }
        public string FlightStatus { get; set; }
        public DateTime Timestamp { get; set; }
        public FlightInformation(string flightNo, string flightStatus, DateTime stamp)
        {
            FlightNumber = flightNo;
            FlightStatus = flightStatus;
            Timestamp = stamp;
        }
    }
}
