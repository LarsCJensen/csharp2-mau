using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Reptile : Animal
    {
        private int length = 0;
        public int Length { 
            get
            {
                return length;
            } 
            set
            {
                if(length > 0 )
                {
                    length = value;
                }
            } 
        }

        public Reptile(int len, string name, int age, GenderType gender, string description) : base(name, age, gender, description)
        {
            length = len;
        }
    }
}