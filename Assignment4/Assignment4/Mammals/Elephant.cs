using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4.Animals;

namespace Assignment4.Mammals
{
    /// <summary>
    /// Class of elephant
    /// </summary>
    [Serializable]
    public class Elephant : Mammal
    {
        private string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
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
        public Elephant(string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int teeth) : base(name, age, gender, eaterType, category, description, teeth)
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
                "\nLocation: ", location);
            return strOut;
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Elephant\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nLocation: ", location);
            return strOut;
        }        
    }
}