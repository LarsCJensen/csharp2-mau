using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment3.Animals;

namespace Assignment3.Reptiles
{
    /// <summary>
    /// Class for Snake
    /// </summary>
    public class Snake : Reptile
    {
        private bool venomous;
        public bool Venomous { 
            get
            {
                return venomous;
            }
            set
            {
                venomous = value;
            } 
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="eaterType">Eater type of mammal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="len">Length of animal(reptile)</param>
        public Snake(string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int len) : base(name, age, gender, eaterType, category, description, len)
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
                "\nVenomous: ", venomous.ToString());
            return strOut;
        }
        
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Snake\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nVenomous: ", venomous.ToString());
            return strOut;
        }
    }
}