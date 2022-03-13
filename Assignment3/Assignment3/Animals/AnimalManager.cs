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
            bool retValue;
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
                if(!retValue)
                {
                    return retValue;
                }
                SetFoodItems(foodItems, animal.Id);                
            }
            else
            {
                retValue = false ;
            }
            return retValue;
        }
        public bool EditAnimal(Animal animal, int index, List<FoodItem> foodItems)
        {
            bool retValue;
            retValue = Edit(animal, index);
            if (!retValue)
            {
                return retValue;
            }
            RemoveFoodItems(animal.Id);
            SetFoodItems(foodItems, animal.Id);

            return retValue;
        }
        /// <summary>
        /// Helper function to add food for an animal
        /// </summary>
        /// <param name="foodItemId">Id of food item</param>
        /// <param name="animalId">Id of animal</param>
        /// <returns>bool</returns>
       private void AddFoodForAnimal(int foodItemId, string animalId)
        {            
            List<string> animalList = new List<string>();
            if (foodAnimalDict.ContainsKey(foodItemId))
            {
                animalList = foodAnimalDict[foodItemId];

            }
            animalList.Add(animalId);
            foodAnimalDict[foodItemId] = animalList;            
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
        /// <summary>
        /// Helper function to set food items for animal
        /// </summary>
        /// <param name="foodItems">List of food items</param>
        /// <param name="animalId">Id of animal</param>
        /// <returns>bool</returns>
        private void SetFoodItems(List<FoodItem> foodItems, string animalId)
        {
            foreach (FoodItem item in foodItems)
            {
                AddFoodForAnimal(item.Id, animalId);
            }            
        }
        private void RemoveFoodItems(string animalId)
        {
            List<string> animalList = new List<string>();
            var matches = foodAnimalDict.Where(x => x.Value.Contains(animalId)).Select(x => x.Key);
            foreach (int match in matches)
            {
                animalList = foodAnimalDict[match];
                animalList.Remove(animalId);
                foodAnimalDict[match] = animalList;
            }            
        }
    }
}
