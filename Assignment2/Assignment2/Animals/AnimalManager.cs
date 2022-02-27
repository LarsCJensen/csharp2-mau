using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Class to manage animal objects
    /// </summary>
    public class AnimalManager
    {
        private List<Animal> animalList = new List<Animal>();
        public List<Animal> AnimalList
        {
            get
            {
                return animalList;
            }
        }

        private int startId = 1000;
        public AnimalManager()
        {

        }
        /// <summary>
        /// Add an animal to list
        /// </summary>
        /// <param name="animal">Animal to add</param>
        /// <returns>If succeeded</returns>
        public bool Add(Animal animal)
        {
            if (animal != null)
            {
                animalList.Add(animal);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Number of animals in list
        /// </summary>
        /// <returns>Number of animals in list</returns>
        public int Count()
        {
            return animalList.Count();
        }
        /// <summary>
        /// Get animal at a certain index
        /// </summary>
        /// <param name="index">Index number</param>
        /// <returns>Animal at intex</returns>
        public Animal GetAnimalAt(int index)
        {
            return animalList[index];
        }
        /// <summary>
        /// Gets all strings for animal
        /// </summary>
        /// <returns></returns>
        public string[] GetAnimalInfoStrings()
        {
            string[] infoStrings = new string[Count()];
            for(int i = 0; i < Count(); i++)
            {
                infoStrings[i] = GetAnimalAt(i).ToString();
            }
            return infoStrings;
        }
        /// <summary>
        /// Method to create an id for an animal
        /// </summary>
        /// <param name="category">Which category to create ID for</param>
        /// <returns>String with prefixed id</returns>
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
