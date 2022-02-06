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
        public string BeeHiveNumber { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="numberOfWings">Number of wings of animal(insect)</param>
        public Bee(string name, int age, GenderType gender, string description, int numberOfWings) : base(numberOfWings, name, age, gender, description)
        {
        }
    }
}