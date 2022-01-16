using System.Collections.Generic;


namespace Assignment2.Animals
{
    /// <summary>
    /// Class for food schedule
    /// </summary>
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
            // Not yet implemented
            //foodList[index] = foodSchedule;
        }
        public bool CheckIndex(int index)
        {
            // Not yet implemted
            return false;
        }
        /// <summary>
        /// Delete food schedule
        /// </summary>
        /// <param name="index">Index of food schedule to delete</param>
        public void DeleteFoodSchedule(int index)
        {
            // Not yet implemented
            //foodList[index] = null;
            //ArrangeFoodSchedule(index);            
        }
        /// <summary>
        /// Return food list as array of strings
        /// </summary>
        /// <returns>Array of strings with food schedule</returns>
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
