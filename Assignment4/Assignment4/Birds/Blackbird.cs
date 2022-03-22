using System;
using Assignment4.Animals;

namespace Assignment4.Birds
{
    /// <summary>
    /// Class of Blackbird
    /// </summary>
    [Serializable]
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
        public Blackbird(int speed, string name, int age, GenderType gender, EaterTypeEnum eaterType, AnimalCategoryEnum category, string description) : base(speed, name, age, gender, eaterType, category, description)
        {
           
        }
        // Default constructor for serilization
        public Blackbird() { }
        /// <summary>
        /// Method to print out mammal information
        /// </summary>
        /// <returns>String of information</returns>
        public override string ToString()
        {
            // First gets base class ToString information
            string strOut = base.ToString();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nIUCN Cat: ", iucnCategorization);
            return strOut;
        }
        public override string GetExtraInfo()
        {
            string strOut = "Blackbird\n\n" + base.GetExtraInfo();
            strOut += string.Format("{0, -15} {1, 6}",
                "\nIUCN Category: ", iucnCategorization);
            return strOut;
        }
    }
}