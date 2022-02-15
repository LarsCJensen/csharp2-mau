using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    /// <summary>
    /// Class of Swallow
    /// </summary>
    public class Swallow : Bird
    {
        private string breed = "";
        public string Breed { 
            get
            {
                return breed;
            } 
            set
            {
                if(value.Length > 0)
                {
                    breed = value;
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
        public Swallow(int speed, string name, int age, GenderType gender, AnimalCategoryEnum category, string description) : base(speed, name, age, gender, category, description)
        {
        }
        /// <summary>
        /// Method to print out mammal information
        /// </summary>
        /// <returns>String of information</returns>
        public override string ToString()
        {
            // First gets base class ToString information
            string strOut = base.ToString();
            strOut += string.Format("{0, -15} {1, 6}",
                "Breed: ", breed);
            return strOut;
        }
    }
}