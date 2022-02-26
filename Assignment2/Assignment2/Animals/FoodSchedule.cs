using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class FoodSchedule
    {
        private List<string> foodList = new List<string>();

        public EaterTypeEnum EaterType { get; set; }

        public int Count { get; private set; }
        public FoodSchedule() { }
        public void Add(string item)
        {
            foodList.Add(item);
            Count += 1;
        }
        /// <summary>
        /// Edit schedule
        /// </summary>
        /// <param index="index">index of schedule to edit</param>
        /// <param name="foodSchedule">food schedule to edit</param>
        public void EditFoodSchedule(int index, FoodSchedule foodSchedule)
        {
            //foodList[index] = foodSchedule;
        }
        public bool CheckIndex(int index)
        {
            return false;
        }
        /// <summary>
        /// Delete food schedule
        /// </summary>
        /// <param name="index">Index of food schedule to delete</param>
        public void DeleteFoodSchedule(int index)
        {
            //recipes[recipeIndex] = null;
            //ArrangeRecipes(recipeIndex);
        }

        public string[] GetFoodListInfoStrings()
        {
            return foodList.ToArray();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
