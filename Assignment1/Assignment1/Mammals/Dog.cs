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
        /// <param name="description">Description of animal</param>
        /// <param name="teeth">Teeth of animal(mammal)</param>
        public Dog(string name, int age, GenderType gender, string description, int teeth) : base(teeth, name, age, gender, description)
        {            
        }
    }
}