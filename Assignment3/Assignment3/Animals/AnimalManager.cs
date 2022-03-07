using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    /// <summary>
    /// Class to manage animal objects
    /// </summary>
    public class AnimalManager: ListManager<Animal>
    {
        private List<Animal> animalList = new List<Animal>();
        //public List<Animal> AnimalList
        //{
        //    get
        //    {
        //        return animalList;
        //    }
        //}

        private int startId = 1000;
        public AnimalManager()
        {

        }
        /// <summary>
        /// Add an animal to list
        /// </summary>
        /// <param name="animal">Animal to add</param>
        /// <returns>If succeeded</returns>
        public bool AddAnimal(Animal animal)
        {
            if (animal != null)
            {
                startId = startId += 1;
                switch (animal.Category)
                {
                    case AnimalCategoryEnum.Mammals:
                        animal.Id = $"M{startId}";
                        break;
                    case AnimalCategoryEnum.Birds:
                        animal.Id = $"B{startId}";
                        break;
                    case AnimalCategoryEnum.Insects:
                        animal.Id = $"I{startId}";
                        break;
                    case AnimalCategoryEnum.Reptiles:
                        animal.Id = $"R{startId}";
                        break;
                    default:
                        animal.Id = $"{startId}";
                        break;
                }
                Add(animal);
                return true;
            }
            else
            {
                return false;
            }
        }        
        
        //public void SortAnimalList(string sortColumn, bool sortDescending)
        public void SortAnimalList(IComparer<Animal> sorter, bool desc)
        {
            if(desc)
            {
                animalList.Sort(new SorterReverse<Animal>(sorter));
            } else
            {
                animalList.Sort(sorter);
            }                   
        }
    }
}
