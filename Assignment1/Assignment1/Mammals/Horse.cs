using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Horse : Mammal
    {
        private string stableBoxNumber;
        public string StableBoxNumber
        {
            get
            {
                return stableBoxNumber;
            }
            set
            {
                stableBoxNumber = value;
            }
        }
        public Horse(string name, int age, GenderType gender, string description, int teeth) : base(teeth, name, age, gender, description)
        {
            stableBoxNumber = "Not set";
        }
    }
}