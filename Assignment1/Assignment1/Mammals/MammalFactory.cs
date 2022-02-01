using System;

namespace Assignment1.Mammals
{
    class MammalFactory
    {
        /// <summary>
        /// Factory for mammal types, to create animal and get types
        /// </summary>
        /// <returns></returns>
        public Array GetAnimalObjects()
        {
            return Enum.GetValues(typeof(MammalTypes)); 
        }

        public Animal CreateAnimal(MammalTypes mammalType, string name, int age, GenderType gender, string description, int teeth)
        {
            switch(mammalType)
            {
                case MammalTypes.Cat: return new Cat(name, age, gender, description, teeth);                    
                case MammalTypes.Dog: return new Dog(name, age, gender, description, teeth);                    
                case MammalTypes.Horse: return new Horse(name, age, gender, description, teeth);
                // TODO Uncomment this, used to test throw
                // case MammalTypes.Elephant: return new Elephant();
                default:
                    // If mammalType is not found throw error
                    throw new ArgumentException("Mammal type not found!");
            }
        }
    }
}
