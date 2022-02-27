using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    public class Dog : Mammal
    {
        /// <summary>
        /// Class of dog
        /// </summary>
        private string breed;
        public string Breed
        {
            get
            {
                return breed;
            }
            set
            {
                if(value is not null)
                {
                    breed = value;
                }                
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
        public Dog(string id, string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int teeth) : base(id, name, age, gender, category, description, teeth)
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
                "\nBreed: ", breed);
            return strOut;
        }
        /// <summary>
        /// Method to print out information
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = "Dog\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nBreed: ", breed);
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
            foodSchedule.Add("Morning: Dog food");
            foodSchedule.Add("Lunch: Apple");
            foodSchedule.Add("Evening: Cat");
        }
    }
}