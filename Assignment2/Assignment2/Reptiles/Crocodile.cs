using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    /// <summary>
    /// Class for crocodile
    /// </summary>
    public class Crocodile : Reptile
    {
        private int numberOfFarmersEaten = 0;
        public int NumberOfFarmersEaten 
        { 
            get
            {
                return numberOfFarmersEaten;
            }
            set 
            {
                numberOfFarmersEaten = value;
            } 
        }
        private FoodSchedule foodSchedule;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="len">Length of animal(reptile)</param>
        public Crocodile(string id, string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int len) : base(id, name, age, gender, category, description, len)
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
                "Farmers eaten: ", numberOfFarmersEaten);
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
            foodSchedule.EaterType = EaterTypeEnum.Carnivore;
            foodSchedule.Add("Morning: Farmer");
            foodSchedule.Add("Lunch: Farmers wife");
            foodSchedule.Add("Evening: Giraffe");
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Crocodile\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nFarmers eaten: ", numberOfFarmersEaten);
            return strOut;
        }
    }
}