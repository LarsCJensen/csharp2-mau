﻿using System;
using System.Collections.Generic;
using Assignment3.Animals;

namespace Assignment3.Insects
{
    class InsectFactory
    {
        /// <summary>
        /// Factory for insects to Create animals and also to return the insect types
        /// </summary>
        /// <returns>Array of insect types</returns>
        public Array GetAnimalObjects()
        {
            return Enum.GetNames(typeof(InsectTypes));
        }
        /// <summary>
        /// Method to create animal of insect type
        /// </summary>
        /// <param name="insectType">Type of insect</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="eaterType">Eater type of mammal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="numberOfWings">Number of wings (insect)</param>
        /// <param name="foodItems">List of strings with food items</param>
        /// <returns>An instance of insect</returns>
        public Animal CreateAnimal(InsectTypes insectType, string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int numberOfWings, List<FoodItem> foodItems)
        {
            switch (insectType)
            {
                case InsectTypes.Bee: return new Bee(name, age, gender, eaterType, category, description, numberOfWings, foodItems);
                case InsectTypes.Butterfly: return new Butterfly(name, age, gender, eaterType, category, description, numberOfWings, foodItems);
                default:
                    // If InsectTypes is not found throw error
                    throw new ArgumentException("Insect type not found!");
            }
        }
    }
}
