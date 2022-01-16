using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    /// <summary>
    /// Class of Bee
    /// </summary>
    public class Bee : Insect
    {
        private string beeHiveNumber;
        public string BeeHiveNumber { 
            get
            {
                return beeHiveNumber;
            } 
            set
            {
                if(value.Length > 0)
                {
                    beeHiveNumber = value;
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
        /// <param name="numberOfWings">Number of wings of animal(insect)</param>
        public Bee(string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int numberOfWings) : base(numberOfWings, name, age, gender, category, description)
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
                "Hive number: ", beeHiveNumber);
            return strOut;
        }
    }
}