using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// Class for LandPlane
    /// </summary>
    public class LandPlane : EventArgs
    {        
        public string FlightNumber { get; set; }
        public string FlightStatus { get; set; }
        public DateTime Timestamp { get; }
        public LandPlane(string flightNo)
        {
            FlightNumber = flightNo;
            FlightStatus = "Landed";
            Timestamp = DateTime.Now;
        }
    }
}
