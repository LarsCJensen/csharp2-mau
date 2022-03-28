using System;
using Assignment4.Animals;

namespace Assignment4.Birds
{
    /// <summary>
    /// Class of Swallow
    /// </summary>
    [Serializable]
    public class Swallow : Bird
    {
        private string breed = "";
        public string Breed { 
            get
            {
                return breed;
            } 
            set
            {
                if(value.Length > 0)
                {
                    breed = value;
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
        public Swallow(int speed, string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description) : base(speed, name, age, gender, eaterType, category, description)
        {           
        }
        // Default constructor for serilization
        public Swallow() { }
        /// <summary>
        /// Method to print out mammal information
        /// </summary>
        /// <returns>String of information</returns>
        public override string ToString()
        {
            // First gets base class ToString information
            string strOut = base.ToString();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nBreed: ", breed);
            return strOut;
        }
        public override string GetExtraInfo()
        {
            string strOut = "Swallow\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nBreed: ", breed);
            return strOut;
        }
        /// <summary>
        /// Method to serialize all values to text
        /// </summary>
        /// <param name="divider">Character to divide parameters</param>
        /// <returns>String separated by character</returns>
        public override string SerializeToText(string divider = ";")
        {
            string serializeString = base.SerializeToText();
            serializeString += $"{breed}{divider}";
            return serializeString;
        }
    }
}