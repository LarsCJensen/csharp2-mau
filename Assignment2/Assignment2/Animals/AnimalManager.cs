using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Animals
{
    /// <summary>
    /// Class to manage animal objects
    /// </summary>
    class AnimalManager
    {
        public List<Animal> animalList;
        private static int idCounter = 1000;
        public int startId;
        public AnimalManager()
        {

        }
        public bool Add(Animal animal)
        {
            return false;
        }
        public int Count()
        {
            return 0;
        }
        public Animal GetAnimalAt(int index)
        {
            return null;
        }
        public string GetAnimalInfoStrings()
        {
            //The method GetAnimalInfoStrings returns  an array(string[])
            //by calling the ToString() method of every element of the list.
            return "None";
        }

        public string GetNewId(AnimalCategoryEnum category)
        {
            startId = startId += 1;
            switch(category)
            {
                case AnimalCategoryEnum.Mammals:
                    return $"M{startId}";
                case AnimalCategoryEnum.Birds:
                    return $"B{startId}";
                case AnimalCategoryEnum.Insects:
                    return $"I{startId}";
                case AnimalCategoryEnum.Reptiles:
                    return $"R{startId}";
                default:
                    return $"{startId}";
            }
        }

    }
}
