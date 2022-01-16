using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="teeth">Teeth of animal(mammal)</param>
        public Dog(string name, int age, GenderType gender, AnimalCategoryEnum category, string description, int teeth) : base(teeth, name, age, gender, category, description)
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
                "Breed: ", breed);
            return strOut;
        }
    }
}