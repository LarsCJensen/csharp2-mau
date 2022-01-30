using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Crocodile : Reptile
    {
        private int numberOfFarmersEaten = 0;
        public int NumberOfFarmersEaten 
        { 
            get
            {
                return numberOfFarmersEaten;
            }
            set 
            {
                numberOfFarmersEaten = value;
            } 
        }

        public Crocodile(int len, string name, int age, GenderType gender, string description) : base(len, name, age, gender, description)
        {
            
        }
    }
}