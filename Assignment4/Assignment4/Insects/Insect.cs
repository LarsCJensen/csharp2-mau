﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4.Animals;

namespace Assignment4.Insects
{
    [Serializable]
    public abstract class Insect : Animal
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
        /// <param name="eaterType">Eater type</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="numWings">Number of wings of animal(insect)</param>


        public Insect(string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int numWings) : base(name, age, gender, eaterType, category, description)
        {
            numberOfWings = numWings;
        }
        // Default constructor for serilization
        public Insect() { }
        /// <summary>
        /// Method to print out mammal information
        /// </summary>
        /// <returns>String of information</returns>
        public override string ToString()
        {
            // First gets base class ToString information
            string strOut = base.ToString();
            strOut += string.Format("{0, -15} {1, 6}\n",
                "Number of wings: ", numberOfWings);
            return strOut;
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}\n",
                "Number of wings: ", numberOfWings);
            return strOut;
        }
        /// <summary>
        /// Method to serialize information about animal
        /// </summary>
        /// <returns>Serialized string</returns>
        public override string SerializeToText(string divider = ";")
        {
            string serializeString = base.SerializeToText();
            serializeString += $"{numberOfWings}{divider}";
            return serializeString;
        }
    }
}