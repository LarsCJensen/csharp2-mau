using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    /// <summary>
    /// Class of bird
    /// </summary>
    public class Bird : Animal
    {
        private int airSpeedVelocity = 0;
        public int AirSpeedVelocity {
            get
            {
                return airSpeedVelocity;
            }
            set
            {
                if(value > 0)
                {
                    airSpeedVelocity = value;
                }
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="speed">Air-speed velocity of animal(bird)</param>
        public Bird(int speed, string name, int age, GenderType gender, AnimalCategoryEnum category, string description) : base(name, age, gender, category,  description)
        {
            airSpeedVelocity = speed;
        }
        /// <summary>
        /// Method to print out mammal information
        /// </summary>
        /// <returns>String of information</returns>
        public override string ToString()
        {
            // First gets base class ToString information
            string strOut = base.ToString();
            strOut += string.Format("{0, -15} {1, 6}\n",
                "Air-speed velocity", airSpeedVelocity);
            return strOut;
        }
    }
}