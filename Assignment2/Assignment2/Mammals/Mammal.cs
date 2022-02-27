﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    /// <summary>
    /// Class for mammal
    /// </summary>
    public abstract class Mammal : Animal
    {
        private int numberOfTeeth = 0;
        public int NumberOfTeeth
        {
            get { return numberOfTeeth; }
            set
            {
                if (value > 0)
                {
                    numberOfTeeth = value;
                }

            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id of teeth</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="teeth">Number of teeth</param>
        public Mammal(string id, string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int teeth) : base(id, name, age, gender, category, description)
        {
            numberOfTeeth = teeth;
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
                "\nNumber of teeth: ", numberOfTeeth);
            return strOut;
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "Number of teeth: ", numberOfTeeth);
            return strOut;
        }
    }
}