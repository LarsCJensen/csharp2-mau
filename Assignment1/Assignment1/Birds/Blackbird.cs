using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Blackbird : Bird
    {
        private string iucnCategorization = "";
        public string IUCNCategorization { 
            get
            {
                return iucnCategorization;
            }
            set
            {
                if(value.Length > 0)
                {
                    iucnCategorization = value;
                }
            } 
        }

        public Blackbird(int speed, string name, int age, GenderType gender, string description) : base(speed, name, age, gender, description)
        {
            
        }
    }
}