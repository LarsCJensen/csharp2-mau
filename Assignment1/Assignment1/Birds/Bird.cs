using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Bird : Animal
    {
        private int airSpeedVelocity = 0;
        public int AirSpeedVelocity {
            get
            {
                return airSpeedVelocity;
            }
            set
            {
                if(value > 0)
                {
                    airSpeedVelocity = value;
                }
            }
        }
        public Bird(int speed, string name, int age, GenderType gender, string description) : base(name, age, gender, description)
        {
            airSpeedVelocity = speed;
        }
    }
}