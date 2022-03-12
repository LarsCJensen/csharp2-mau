using System.Collections.Generic;
using Assignment3.Animals;

namespace Assignment3.Birds
{
    /// <summary>
    /// Class of Swallow
    /// </summary>
    public class Swallow : Bird
    {
        private string breed = "";
        public string Breed { 
            get
            {
                return breed;
            } 
            set
            {
                if(value.Length > 0)
                {
                    breed = value;
                }
            } 
        }
        //private FoodSchedule foodSchedule;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="speed">Air-speed velocity of animal(bird)</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="eaterType">Eater type</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        public Swallow(int speed, string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description) : base(speed, name, age, gender, eaterType, category, description)
        {
            //SetFoodSchedule(foodItems);
        }
        /// <summary>
        /// Method to print out mammal information
        /// </summary>
        /// <returns>String of information</returns>
        public override string ToString()
        {
            // First gets base class ToString information
            string strOut = base.ToString();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nBreed: ", breed);
            return strOut;
        }
        //public override FoodSchedule GetFoodSchedule()
        //{
        //    return foodSchedule;
        //}
        /// <summary>
        /// Method to set food schedule
        /// </summary>
        //private void SetFoodSchedule(List<FoodItem> foodItems)
        //{
        //    foodSchedule = new FoodSchedule();
        //    foodSchedule.EaterType = EaterTypeEnum.Herbivore;
        //    foreach(FoodItem item in foodItems)
        //    {
        //        //foodSchedule.Add(item);
        //    }
        //    // TODO Ta bort
        //    //foodSchedule.Add("Morning: Seeds");
        //    //foodSchedule.Add("Lunch: Fruit");
        //    //foodSchedule.Add("Evening: Coconut");
        //}
        public override string GetExtraInfo()
        {
            string strOut = "Swallow\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nBreed: ", breed);
            return strOut;
        }
    }
}