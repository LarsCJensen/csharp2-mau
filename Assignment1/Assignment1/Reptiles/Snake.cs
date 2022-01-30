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

        public Snake(int len, string name, int age, GenderType gender, string description) : base(len, name, age, gender, description)
        {

        }
    }
}