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

        private EaterTypeEnum eaterType;
        public EaterTypeEnum EaterType
        {
            get
            {
                return eaterType;
            }
            set
            {
                eaterType = value;
            }
        }
        private int count;
        public int Count
        {
            get
            {
                return count;
            }
        }
        public FoodSchedule() { }
        public void Add(string item)
        {
            foodList.Add(item);
        }
        /// <summary>
        /// Edit schedule
        /// </summary>
        /// <param name="index">index of schedule to edit</param>
        /// <param name="foodSchedule">food schedule to edit</param>
        public void EditRecipe(int index, FoodSchedule foodSchedule)
        {
            //recipes[index] = recipe;
        }
        public bool CheckIndex(int index)
        {
            return false;
        }
        /// <summary>
        /// Delete food schedule
        /// </summary>
        /// <param name="index">Index of food schedule to delete</param>
        public void DeleteRecipe(int index)
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
