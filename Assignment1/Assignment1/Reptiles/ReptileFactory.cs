using System;

namespace Assignment1.Reptiles
{
    class ReptileFactory
    {
        /// <summary>
        /// Factory for reptiles to create animals and also to return the reptile types
        /// </summary>
        /// <returns>Array of enums of Reptile Types</returns>
        public Array GetAnimalObjects()
        {
            return Enum.GetValues(typeof(ReptileTypes));
        }

        /// <summary>
        /// Method to create animal of reptile class
        /// </summary>
        /// <param name="reptileType">Type of reptile</param>
        /// <param name="name">Name if reptile</param>
        /// <param name="age">Age if reptile</param>
        /// <param name="gender">Gender of reptile</param>
        /// <param name="description">Description of reptile</param>
        /// <param name="len">Length of reptile</param>
        /// <returns>An instance of reptile</returns>
        public Animal CreateAnimal(ReptileTypes reptileType, string name, int age, GenderType gender, string description, int len)
        {
            switch (reptileType)
            {
                case ReptileTypes.Crocodile: return new Bee(name, age, gender, description, len);
                case ReptileTypes.Snake: return new Butterfly(name, age, gender, description, len);
                default:
                    // If ReptileTypes is not found throw error
                    throw new ArgumentException("Reptile type not found!");
            }
        }
    }
}
