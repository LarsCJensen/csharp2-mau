using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment4.Animals;

namespace Assignment4.Mammals
{
    [Serializable]
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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="eaterType">Eater type</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="teeth">Teeth of animal(mammal)</param>
        public Dog(string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description, int teeth) : base(name, age, gender, eaterType, category, description, teeth)
        {
           
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
    }
}