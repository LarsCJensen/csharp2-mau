using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    /// <summary>
    /// Class of elephant
    /// </summary>
    public class Elephant : Mammal
    {
        private string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
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
        public Elephant(string id, string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int teeth) : base(id, name, age, gender, category, description, teeth)
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
                "Location: ", location);
            return strOut;
        }

        public override string GetExtraInfo()
        {
            string strOut = "Elephant\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nLocation: ", location);
            return strOut;
        }
        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }


        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterTypeEnum.Carnivore;
            foodSchedule.Add("Morning: Tuna");
            foodSchedule.Add("Lunch: Chicken");
            foodSchedule.Add("Evening: Cucumber");
        }
    }
}