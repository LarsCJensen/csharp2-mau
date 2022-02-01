using System;

namespace Assignment1.Reptiles
{
    class ReptileFactory
    {
        /// <summary>
        /// Factory for reptiles to create animals and also to return the reptile types
        /// </summary>
        /// <returns></returns>
        public Array GetAnimalObjects()
        {
            return Enum.GetValues(typeof(ReptileTypes));
        }

        public Animal CreateAnimal(ReptileTypes insectType, string name, int age, GenderType gender, string description, int len)
        {
            switch (insectType)
            {
                case ReptileTypes.Crocodile: return new Bee(name, age, gender, description, len);
                case ReptileTypes.Snake: return new Butterfly(name, age, gender, description, len);
                default:
                    // If InsectTypes is not found throw error
                    throw new ArgumentException("Reptile type not found!");
            }
        }
    }
}
