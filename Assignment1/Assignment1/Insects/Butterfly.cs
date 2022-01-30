using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Butterfly : Insect
    {
        private string mainColor = "";
        public string MainColor { 
            get
            {
                return mainColor;
            }
            set
            {
                if(value.Length > 0)
                {
                    mainColor = value;
                }
            }         
        }

        public Butterfly(string name, int age, GenderType gender, string description, int numberOfWings) : base(numberOfWings, name, age, gender, description)
        {

        }
    }
}