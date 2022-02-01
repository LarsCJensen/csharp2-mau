using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Birds
{
    class BirdFactory
    {
        /// <summary>
        /// Factory for birds to create animals and also to return the bird types
        /// </summary>
        /// <returns></returns>
        public Array GetAnimalObjects()
        {
            return Enum.GetValues(typeof(BirdTypes));
        }

        public Animal CreateAnimal(BirdTypes birdType, string name, int age, GenderType gender, string description, int speed)
        {
            switch (birdType)
            {
                case BirdTypes.Blackbird: return new Bee(name, age, gender, description, speed);
                case BirdTypes.Swallow: return new Butterfly(name, age, gender, description, speed);
                default:
                    // If InsectTypes is not found throw error
                    throw new ArgumentException("Bird type not found!");
            }
        }
    }
}
