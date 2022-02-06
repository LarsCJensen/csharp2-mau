using System;

namespace Assignment1.Mammals
{
    /// <summary>
    /// Factory for mammal types, to create animal and get types
    /// </summary>
    class MammalFactory
    {
        
        /// <summary>
        /// Method to return all enums of Mammal types
        /// </summary>
        /// <returns>Array of mammal types</returns>        
        public Array GetAnimalObjects()
        {
            return Enum.GetValues(typeof(MammalTypes)); 
        }
        /// <summary>
        /// Method to create an animal of mammal type
        /// </summary>
        /// <param name="mammalType">Which mammal to create an object of</param>
        /// <param name="name">Name of mammal</param>
        /// <param name="age">Age of mammal</param>
        /// <param name="gender">Gender of mammal</param>
        /// <param name="description">Description of mammal</param>
        /// <param name="teeth">Number of teeth of mammal</param>
        /// <returns>An instance of mammal</returns>
        public Animal CreateAnimal(MammalTypes mammalType, string name, int age, GenderType gender, string description, int teeth)
        {
            switch(mammalType)
            {
                case MammalTypes.Cat: return new Cat(name, age, gender, description, teeth);                    
                case MammalTypes.Dog: return new Dog(name, age, gender, description, teeth);                    
                case MammalTypes.Horse: return new Horse(name, age, gender, description, teeth);
                case MammalTypes.Elephant: return new Elephant(name, age, gender, description, teeth);
                default:
                    // If mammalType is not found throw error
                    throw new ArgumentException("Mammal type not found!");
            }
        }
    }
}
