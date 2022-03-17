using System;
using System.Collections.Generic;
using System.Linq;
using Assignment3.Animals;

namespace Assignment3.Mammals
{
    /// <summary>
    /// Class for Horse
    /// </summary>
    public class Horse : Mammal
    {
        private string stableBoxNumber;
        public string StableBoxNumber
        {
            get
            {
                return stableBoxNumber;
            }
            set
            {
                stableBoxNumber = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="eaterType">Eater type</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="teeth">Teeth of animal(mammal)</param>
        public Horse(string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int teeth) : base(name, age, gender, eaterType, category, description, teeth)
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
                "\nBox number: ", stableBoxNumber);
            return strOut;
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Horse\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nBox number: ", stableBoxNumber);
            return strOut;
        }

    }
}