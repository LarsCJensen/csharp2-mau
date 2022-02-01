using System;

namespace Assignment1.Insects
{
    class InsectFactory
    {
        /// <summary>
        /// Factory for insects to Create animals and also to return the insect types
        /// </summary>
        /// <returns></returns>
        public Array GetAnimalObjects()
        {
            return Enum.GetValues(typeof(InsectTypes));
        }

        public Animal CreateAnimal(InsectTypes insectType, string name, int age, GenderType gender, string description, int numberOfWings)
        {
            switch (insectType)
            {
                case InsectTypes.Bee: return new Bee(name, age, gender, description, numberOfWings);
                case InsectTypes.Butterfly: return new Butterfly(name, age, gender, description, numberOfWings);
                default:
                    // If InsectTypes is not found throw error
                    throw new ArgumentException("Insect type not found!");
            }
        }
    }
}
