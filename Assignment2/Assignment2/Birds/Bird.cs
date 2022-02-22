using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    /// <summary>
    /// Class of bird
    /// </summary>
    public abstract class Bird : Animal
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
        /// <param name="speed">Air-speed velocity of animal(bird)</param>
        /// <param name="id">Id of animal</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        public Bird(int speed, string id, string name, int age, GenderType gender, AnimalCategoryEnum category, string description) : base(id, name, age, gender, category, description)
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