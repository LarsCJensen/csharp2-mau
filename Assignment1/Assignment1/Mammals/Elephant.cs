using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Elephant : Mammal
    {
        private string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }
        public Elephant(string name, int age, GenderType gender, string description, int teeth) : base(teeth, name, age, gender, description)
        {
            location = "Not set";
        }
    }
}