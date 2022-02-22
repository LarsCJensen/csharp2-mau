using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    public abstract class Animal: IAnimal, IComparable<Animal>
    {
        /// <summary>
        /// Class which holds general fields and methods for all animals
        /// </summary>
        /// 
        // Wanted to try to use a static field to check how many animals that have been created
        public static int NumberOfAnimalsCreated = 0;
        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                // TODO
                // Should we set id here with prefix?
                if(value != string.Empty)
                {
                    id = value;
                }                    
            }
        }

        private string name; 
        public string Name {
            get {
                return name;
            }
            set 
            { 
                if(value != string.Empty)
                {
                    name = value;
                }
            }
        }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }
        private GenderType gender;
        public GenderType Gender {             
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        private AnimalCategoryEnum category;
        public AnimalCategoryEnum Category { 
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }
        private string description;
        public string Description { 
            get
            {
                return description;
            }
            set
            {
                if(value != string.Empty)
                {
                    description = value;
                }
            }
        }
        public abstract FoodSchedule GetFoodSchedule();
        /// <summary>
        /// Default sort method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Animal other)
        {
            return String.Compare(this.name, other.name);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="animalName">Name of animal</param>
        /// <param name="animalAge">Age of animal</param>
        /// <param name="animalGender">Gender of animal</param>
        /// <param name="animalCategory">Category of animal</param>
        /// <param name="animalDesc">Description of animal</param>
        public Animal(string newId, string animalName, int animalAge, GenderType animalGender, AnimalCategoryEnum animalCategory, string animalDesc)
        {
            id = newId;
            name = animalName;
            age = animalAge;
            gender = animalGender;
            category = animalCategory;
            description = animalDesc;

            NumberOfAnimalsCreated++;
        }

        
        /// <summary>
        /// Method to print out animal information
        /// </summary>
        /// <returns>String of information</returns>
        //public override string ToString()
        //{
        //    string strOut = string.Format("{0, -15} {1, 6}\n{2, -15} {3, 6}\n{4, -15} {5,6}\n",
        //        "ID", id, "Name: ", name, "Age", age);
        //    strOut += string.Format("{0, -15} {1, 6}\n{2, -15} {3, 6}\n{4, -15} {5,6}\n",
        //        "Gender: ", gender.ToString(), "Category: ", category.ToString(), "Description: ", description);
        //    return strOut;
        //}

        public virtual string GetExtraInfo() {
            // The virtual method GetExraInfo is intended to contain a string with values from the
            // category-level classes(Mammals, etc.).  For example, a  Dog class must  give information
            // about the instances variables defined in the Dog class (e.g.Breed) as well as data in the
            // Mammal class.  (numOfTeeth, tailLength).  This method can be overridden in a concrete
            // class such as the Dog class. 
            string strOut = string.Format("{0, -15} {1, 6}\n",
                "Category: ", category);
            strOut += string.Format("{0, -15}\n",
                "Description: ");
            strOut += string.Format("{0, -15}\n\n",
                description);

            return strOut; 
        }

        
    }
}