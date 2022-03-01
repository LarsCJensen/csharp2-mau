using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2.Animals;

namespace Assignment2.Birds
{
    /// <summary>
    /// Class of Blackbird
    /// </summary>
    public class Blackbird : Bird
    {
        private string iucnCategorization = "";
        public string IUCNCategorization { 
            get
            {
                return iucnCategorization;
            }
            set
            {
                if(value.Length > 0)
                {
                    iucnCategorization = value;
                }
            } 
        }
        private FoodSchedule foodSchedule;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="speed">Air-speed velocity of animal(bird)</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        public Blackbird(int speed, string name, int age, GenderType gender, AnimalCategoryEnum category, string description) : base(speed, name, age, gender, category, description)
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
                "\nIUCN Cat: ", iucnCategorization);
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
            foodSchedule.EaterType = EaterTypeEnum.Omnivorous;
            foodSchedule.Add("Morning: Seeds");
            foodSchedule.Add("Lunch: Worm");
            foodSchedule.Add("Evening: Banana");
        }
        public override string GetExtraInfo()
        {
            string strOut = "Blackbird\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nIUCN Category: ", iucnCategorization);
            return strOut;
        }
    }
}