using Assignment4.Animals;
using System;

namespace Assignment4.Birds
{
    /// <summary>
    /// Class of bird
    /// </summary>
    /// 
    [Serializable]
    public abstract class Bird : Animal
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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="speed">Air-speed velocity of animal(bird)</param>
        /// <param name="name">Name of animal</param>
        /// <param name="age">Age of animal</param>
        /// <param name="gender">Gender of animal</param>
        /// <param name="eaterType">Eater type</param>
        /// <param name="category">Category of animal</param>
        /// <param name="description">Description of animal</param>
        public Bird(int speed, string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description) : base(name, age, gender, eaterType, category, description)
        {
            airSpeedVelocity = speed;
        }
        // Default constructor for serilization
        public Bird() { }
        /// <summary>
        /// Method to print out mammal information
        /// </summary>
        /// <returns>String of information</returns>
        public override string ToString()
        {
            // First gets base class ToString information
            string strOut = base.ToString();
            strOut += string.Format("{0, -15} {1, 6}",
                "Air-speed velocity", airSpeedVelocity);
            return strOut;
        }
        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "Air-speed velocity", airSpeedVelocity);
            return strOut;
        }
    }
}