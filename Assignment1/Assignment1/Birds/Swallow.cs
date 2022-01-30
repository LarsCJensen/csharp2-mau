using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
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
        public Swallow(int speed, string name, int age, GenderType gender, string description) : base(speed, name, age, gender, description)
        {

        }
    }
}