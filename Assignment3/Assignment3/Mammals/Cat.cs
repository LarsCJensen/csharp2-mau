﻿using System.Collections.Generic;
using Assignment3.Animals;

namespace Assignment3.Mammals
{
    /// <summary>
    /// Class of cat
    /// </summary>
    public class Cat : Mammal
    {
        private bool indoor;
        public bool Indoor
        {
            get
            {
                return indoor;
            }
            set 
            {
                indoor = value;
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
        public Cat(string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int teeth) : base(name, age, gender, eaterType, category, description, teeth)
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
                "\nIndoor: ", indoor.ToString());
            return strOut;
        }

        public override string GetExtraInfo()
        {
            string strOut = "Cat\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nIndoor: ", indoor.ToString());
            return strOut;
        }        
    }
}