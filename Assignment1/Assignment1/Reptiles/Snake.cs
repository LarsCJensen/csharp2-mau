using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
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

        public Snake(string name, int age, GenderType gender, string description, int len) : base(len, name, age, gender, description)
        {

        }
    }
}