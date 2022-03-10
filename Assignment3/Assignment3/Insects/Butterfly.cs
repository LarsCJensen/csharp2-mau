using System;
using System.Collections.Generic;
using System.Linq;
using Assignment3.Animals;

namespace Assignment3.Insects
{
    /// <summary>
    /// Class for Butterfly
    /// </summary>
    public class Butterfly : Insect
    {
        private string mainColor = "";
        public string MainColor { 
            get
            {
                return mainColor;
            }
            set
            {
                if(value.Length > 0)
                {
                    mainColor = value;
                }
            }         
        }
        private FoodSchedule foodSchedule;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="eaterType">Eater type</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="numberOfWings">Number of wings of insect</param>
        /// <param name="foodItems">List of food items</param>

        public Butterfly(string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int numberOfWings, List<FoodItem> foodItems) : base(name, age, gender, eaterType, category, description, numberOfWings)
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
                "\nMain color: ", mainColor);
            return strOut;
        }
        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
        /// <summary>
        /// Method to set food schedule
        /// </summary>
        private void SetFoodSchedule(List<FoodItem> foodItems)
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterTypeEnum.Herbivore;
            foreach (FoodItem item in foodItems)
            {
                //foodSchedule.Add(item);
            }
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Butterfly\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}\n",
                "Main color: ", mainColor);
            return strOut;
        }
    }
}