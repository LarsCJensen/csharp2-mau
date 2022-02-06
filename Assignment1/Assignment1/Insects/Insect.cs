﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Insect : Animal
    {
        /// <summary>
        /// Class for all animals of insect type
        /// </summary>
        private int numberOfWings = 0;
        public int NumberOfWings { 
            get
            {
                return numberOfWings;
            }
            set
            {
                // There are insects without wings so no check for > 0
                numberOfWings = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="numWings">Number of wings of animal(insect)</param>
        public Insect(int numWings, string name, int age, GenderType gender, string description) : base(name, age, gender, description)
        {
            numberOfWings = numWings;
        }
    }
}