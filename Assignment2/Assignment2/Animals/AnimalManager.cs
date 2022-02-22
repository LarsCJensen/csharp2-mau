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

        public int startId = 1000;
        public AnimalManager()
        {

        }
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
        public int Count()
        {
            return 0;
        }
        public Animal GetAnimalAt(int index)
        {
            return animalList[index];
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
        //public List<Animal> GetSortedList(string sortBy)
        //{
        //    return List<Animal>.Sort(animalList);
        //}
    }
}
