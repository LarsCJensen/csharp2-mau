using System;
using System.Collections.Generic;
using System.Linq;
using Assignment3.Animals;

namespace Assignment3.Insects
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
        /// <param name="eaterType">Eater type</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="numberOfWings">Number of wings of animal(insect)</param>
        public Bee(string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int numberOfWings) : base(name, age, gender, eaterType, category, description, numberOfWings)
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
                "\nHive number: ", beeHiveNumber);
            return strOut;
        }
        
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Bee\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}\n",
                "Hive number: ", beeHiveNumber);
            return strOut;
        }
    }
}