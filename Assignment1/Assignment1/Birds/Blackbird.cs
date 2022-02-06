using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    /// <summary>
    /// Class of Blackbird
    /// </summary>
    public class Blackbird : Bird
    {
        private string iucnCategorization = "";
        public string IUCNCategorization { 
            get
            {
                return iucnCategorization;
            }
            set
            {
                if(value.Length > 0)
                {
                    iucnCategorization = value;
                }
            } 
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="speed">Air-speed velocity of animal(bird)</param>
        public Blackbird(string name, int age, GenderType gender, string description, int speed) : base(speed, name, age, gender, description)
        {
            
        }
    }
}