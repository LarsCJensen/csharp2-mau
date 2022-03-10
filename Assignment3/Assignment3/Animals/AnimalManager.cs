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

        private int startId = 1000;
        private Dictionary<int, List<string>> foodAnimalDict;
        public Dictionary<int, List<string>> FoodAnimalDict
        {
            get
            {
                return foodAnimalDict;
            }
        }

        public AnimalManager()
        {
            foodAnimalDict = new Dictionary<int, List<string>>();
        }
        /// <summary>
        /// Add an animal to list
        /// </summary>
        /// <param name="animal">Animal to add</param>
        /// <returns>If succeeded</returns>
        public bool AddAnimal(Animal animal, List<FoodItem> foodItems)
        {
            bool retValue = false;
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
                retValue = Add(animal);
                foreach(FoodItem item in foodItems)
                {
                    retValue = AddFoodForAnimal(item.Id, animal.Id);
                }
                
            }
            else
            {
                retValue = false ;
            }
            return retValue;
        }        
        
        //public void SortAnimalList(string sortColumn, bool sortDescending)
        //public void SortAnimalList(IComparer<Animal> sorter, bool desc)
        //{
        //    if(desc)
        //    {
        //        animalList.Sort(new SorterReverse<Animal>(sorter));
        //    } else
        //    {
        //        animalList.Sort(sorter);
        //    }                   
        //}
        private bool AddFoodForAnimal(int foodItemId, string animalId)
        {
            // TODO Add check for things
            List<string> animalList = new List<string>();
            if (foodAnimalDict.ContainsKey(foodItemId))
            {
                animalList = foodAnimalDict[foodItemId];

            }
            animalList.Add(animalId);
            foodAnimalDict[foodItemId] = animalList;
            return true;
        }
        /// <summary>
        /// Get food schedule for animal
        /// </summary>
        /// <param name="animalId">id of animal</param>
        /// <returns>Array of food item strings</returns>
        public int[] GetFoodSchedule(string animalId)
        {
            var matches = foodAnimalDict.Where(x => x.Value.Contains(animalId)).Select(x => x.Key);            
            return matches.ToArray();
        }
    }
}
