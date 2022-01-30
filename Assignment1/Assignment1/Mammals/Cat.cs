using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Cat : Mammal
    {
        private bool indoor;
        public bool Indoor
        {
            get
            {
                return indoor;
            }
            set 
            {
                indoor = value;
            }
        }
        public Cat(string name, int age, GenderType gender, string description, int teeth) : base(teeth, name, age, gender, description)
        {
            indoor = false;
        }
    }
}