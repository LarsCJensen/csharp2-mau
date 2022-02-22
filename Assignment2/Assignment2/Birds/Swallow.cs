using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
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
        private FoodSchedule foodSchedule;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="speed">Air-speed velocity of animal(bird)</param>
        /// <param name="id">Id of animal</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        public Swallow(int speed, string id, string name, int age, GenderType gender, AnimalCategoryEnum category, string description) : base(speed, id, name, age, gender, category, description)
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
                "Breed: ", breed);
            return strOut;
        }
        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterTypeEnum.Herbivore;
            foodSchedule.Add("Morning: Seeds");
            foodSchedule.Add("Lunch: Fruit");
            foodSchedule.Add("Evening: Coconut");
        }
        public override string GetExtraInfo()
        {
            string strOut = "Swallow\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nBreed: ", breed);
            return strOut;
        }
    }
}