using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Mammal : Animal
    {
        private int numberOfTeeth = 0;
        public int NumberOfTeeth
        {
            get { return numberOfTeeth; }
            set
            {
                if (value > 0)
                {
                    numberOfTeeth = value;
                }

            }
        }

        public Mammal(int teeth, string name, int age, GenderType gender, string description) : base(name, age, gender, description)
        {
            numberOfTeeth = teeth;
        }
    }
}