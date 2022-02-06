using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    /// <summary>
    /// Class for mammal
    /// </summary>
    public class Mammal : Animal
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
        /// <param name="teeth">Number of teeth</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="description">Description of animal</param>
        public Mammal(int teeth, string name, int age, GenderType gender, string description) : base(name, age, gender, description)
        {
            numberOfTeeth = teeth;
        }
    }
}