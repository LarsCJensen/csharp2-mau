using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    /// <summary>
    /// Class for Horse
    /// </summary>
    public class Horse : Mammal
    {
        private string stableBoxNumber;
        public string StableBoxNumber
        {
            get
            {
                return stableBoxNumber;
            }
            set
            {
                stableBoxNumber = value;
            }
        }
        private FoodSchedule foodSchedule;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id of animal</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="teeth">Teeth of animal(mammal)</param>
        public Horse(string id, string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int teeth) : base(id, name, age, gender, category, description, teeth)
        {
            SetFoodSchedule();
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
                "\nBox number: ", stableBoxNumber);
            return strOut;
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Horse\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nBox number: ", stableBoxNumber);
            return strOut;
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
        /// <summary>
        /// Method to set food schedule
        /// </summary>

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterTypeEnum.Herbivore;
            foodSchedule.Add("Morning: Grass");
            foodSchedule.Add("Lunch: Hay");
            foodSchedule.Add("Evening: Sugar");
        }
    }
}