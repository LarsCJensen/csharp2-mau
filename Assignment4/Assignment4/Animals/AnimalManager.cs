using System.Collections.Generic;
using System.Linq;
using Assignment4.Helpers;

namespace Assignment4.Animals
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
        public bool AddAnimal(Animal animal)
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
            }
            else
            {
                retValue = false ;
            }
            return retValue;
        }        
        /// <summary>
        /// Helper function to add food for an animal
        /// </summary>
        /// <param name="foodItemId">Id of food item</param>
        /// <param name="animalId">Id of animal</param>
        /// <returns>bool</returns>
        public void AddFoodForAnimal(List<FoodItem> foodItems, string animalId)
        {
            // First remove all existing food items for animal
            RemoveFoodItems(animalId);
            // Then add them to dict
            foreach (FoodItem item in foodItems)
            {

                List<string> animalList = new List<string>();
                if (foodAnimalDict.ContainsKey(item.Id))
                {
                    animalList = foodAnimalDict[item.Id];

                }
                animalList.Add(animalId);
                foodAnimalDict[item.Id] = animalList;
            }
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
