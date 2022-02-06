using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
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
        /// <param name="description">Description of animal</param>
        /// <param name="teeth">Teeth of animal(mammal)</param>
        public Horse(string name, int age, GenderType gender, string description, int teeth) : base(teeth, name, age, gender, description)
        {
         
        }
    }
}