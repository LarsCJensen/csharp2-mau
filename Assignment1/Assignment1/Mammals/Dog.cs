using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Dog : Mammal
    {
        private string breed;
        public string Breed
        {
            get
            {
                return breed;
            }
            set
            {
                if(breed is not null)
                {
                    breed = value;
                }                
            }
        }
        public Dog(string name, int age, GenderType gender, string description, int teeth) : base(teeth, name, age, gender, description)
        {
            breed = "Not set";
        }
    }
}