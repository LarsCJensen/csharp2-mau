using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assignment2
{
    /// <summary>
    /// Class for Snake
    /// </summary>
    public class Snake : Reptile
    {
        private bool venomous;
        public bool Venomous { 
            get
            {
                return venomous;
            }
            set
            {
                venomous = value;
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
        /// <param name="len">Length of animal(reptile)</param>
        public Snake(string id, string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int len) : base(id, name, age, gender, category, description, len)
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
                "Venomous: ", venomous.ToString());
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
            foodSchedule.Add("Morning: Man");
            foodSchedule.Add("Lunch: Nothing (digesting)");
            foodSchedule.Add("Evening: Nothing (digesting)");
        }
        public override string GetExtraInfo()
        {
            string strOut = "Snake\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nVenomous: ", venomous.ToString());
            return strOut;
        }
    }
}