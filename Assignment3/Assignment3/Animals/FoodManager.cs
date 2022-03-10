using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    /// <summary>
    /// TODO Write
    /// </summary>    
    public class FoodManager
    {
        // TODO SHOULD THIS inherit ListManager?
        private List<FoodItem> foodItems = new List<FoodItem>();
        public List<FoodItem> FoodItems
        {
            get
            {
                return foodItems;
            }                 
        }
        public void Add(FoodItem foodItem)
        {
            if(foodItem != null)
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
