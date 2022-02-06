using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    /// <summary>
    /// Class for reptile
    /// </summary>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="description">Description of animal</param>
        /// <param name="len">Length of animal(reptile)</param>
        public Reptile(int len, string name, int age, GenderType gender, string description) : base(name, age, gender, description)
        {
            length = len;
        }
    }
}