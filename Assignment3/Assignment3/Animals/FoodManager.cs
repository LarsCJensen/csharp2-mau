using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    /// <summary>
    /// Manager for food
    /// </summary>    
    /// This could inherit ListManager, but getting a food item is a bit special so decided to make it like this
    public class FoodManager
    {
        
        private List<FoodItem> foodItems = new List<FoodItem>();
        public List<FoodItem> FoodItems
        {
            get
            {
                return foodItems;
            }
        }
        /// <summary>
        /// Add food item
        /// </summary>
        /// <param name="foodItem">Food item to add to list</param>
        public void Add(FoodItem foodItem)
        {
            if (foodItem != null)
            {
                foodItems.Add(foodItem);
            }
        }
        /// <summary>
        /// Get food item
        /// </summary>
        /// <param name="foodItemId">Id of food item</param>
        /// <returns></returns>
        public FoodItem GetFoodItem(int foodItemId)
        {
            return foodItems.Find(item => item.Id == foodItemId);
        }        
    }
}
