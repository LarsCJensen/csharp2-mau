using System;
using System.Collections.Generic;
using Assignment3.Animals;

namespace Assignment3.Reptiles
{
    class ReptileFactory
    {
        /// <summary>
        /// Factory for reptiles to create animals and also to return the reptile types
        /// </summary>
        /// <returns>Array of enums of Reptile Types</returns>
        public Array GetAnimalObjects()
        {
            return Enum.GetNames(typeof(ReptileTypes));
        }

        /// <summary>
        /// Method to create animal of reptile class
        /// </summary>
        /// <param name="reptileType">Type of reptile</param>
        /// <param name="name">Name if reptile</param>
        /// <param name="age">Age if reptile</param>
        /// <param name="gender">Gender of reptile</param>
        /// <param name="eaterType">Eater type of mammal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of reptile</param>
        /// <param name="len">Length of reptile</param>
        /// <param name="foodItems">List of food items</param>
        /// <returns>An instance of reptile</returns>
        public Animal CreateAnimal(ReptileTypes reptileType, string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int len, List<FoodItem> foodItems)
        {
            switch (reptileType)
            {
                case ReptileTypes.Crocodile: return new Crocodile(name, age, gender, eaterType, category, description, len, foodItems);
                case ReptileTypes.Snake: return new Snake(name, age, gender, eaterType, category, description, len, foodItems);
                default:
                    // If ReptileTypes is not found throw error
                    throw new ArgumentException("Reptile type not found!");
            }
        }
    }
}
