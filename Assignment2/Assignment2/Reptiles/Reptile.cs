using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    /// <summary>
    /// Class for reptile
    /// </summary>
    public abstract class Reptile : Animal
    {
        private int length = 0;
        public int Length { 
            get
            {
                return length;
            } 
            set
            {
                if(length > 0 )
                {
                    length = value;
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
        /// <param name="len">Length of animal(reptile)</param>
        public Reptile(string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int len) : base(name, age, gender, category, description)
        {
            length = len;
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
                "Length: ", length);
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
                "Length: ", length);
            return strOut;
        }
    }
}