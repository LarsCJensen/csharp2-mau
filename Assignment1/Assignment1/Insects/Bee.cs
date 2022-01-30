using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Bee : Insect
    {
        public string BeeHiveNumber { get; set; }

        public Bee(string name, int age, GenderType gender, string description, int numberOfWings) : base(numberOfWings, name, age, gender, description)
        {

        }
    }
}