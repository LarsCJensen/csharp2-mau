using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2.Animals;

namespace Assignment2.Insects
{
    /// <summary>
    /// Class of Bee
    /// </summary>
    public class Bee : Insect
    {
        private string beeHiveNumber;
        public string BeeHiveNumber { 
            get
            {
                return beeHiveNumber;
            } 
            set
            {
                if(value.Length > 0)
                {
                    beeHiveNumber = value;
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
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="numberOfWings">Number of wings of animal(insect)</param>
        public Bee(string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int numberOfWings) : base(name, age, gender, category, description, numberOfWings)
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
                "\nHive number: ", beeHiveNumber);
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
            foodSchedule.Add("Morning: Nectar");
            foodSchedule.Add("Lunch: Nectar");
            foodSchedule.Add("Evening: Wood");
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Bee\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}\n",
                "Hive number: ", beeHiveNumber);
            return strOut;
        }
    }
}