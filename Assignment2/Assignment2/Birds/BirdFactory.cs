using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Birds
{
    class BirdFactory
    {
        /// <summary>
        /// Factory for birds to create animals and also to return the bird types
        /// </summary>
        /// <returns>Array of bird enums</returns>
        public Array GetAnimalObjects()
        {
            return Enum.GetValues(typeof(BirdTypes));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="birdType">Type of bird</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="speed">Air-speed velocity of bird</param>
        /// <returns>Instance of bird</returns>
        public Animal CreateAnimal(BirdTypes birdType, string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int speed)
        {
            switch (birdType)
            {
                case BirdTypes.Blackbird: return new Bee(name, age, gender, category, description, speed);
                case BirdTypes.Swallow: return new Butterfly(name, age, gender, category, description, speed);
                default:
                    // If InsectTypes is not found throw error
                    throw new ArgumentException("Bird type not found!");
            }
        }
    }
}
