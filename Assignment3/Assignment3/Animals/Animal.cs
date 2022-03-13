using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment3.Animals
{
    public abstract class Animal: IAnimal
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
        private EaterTypeEnum eaterType;
        public EaterTypeEnum EaterType
        {
            get
            {
                return eaterType;
            }
            set
            {
                eaterType = value;
            }
        }        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="animalName">Name of animal</param>
        /// <param name="animalAge">Age of animal</param>
        /// <param name="animalGender">Gender of animal</param>
        /// <param name="animalCategory">Category of animal</param>
        /// <param name="animalDesc">Description of animal</param>
        public Animal(string animalName, int animalAge, GenderType animalGender, EaterTypeEnum animalEaterType, AnimalCategoryEnum animalCategory, string animalDesc)
        {
            name = animalName;
            age = animalAge;
            gender = animalGender;
            eaterType = animalEaterType;
            category = animalCategory;
            description = animalDesc;

            NumberOfAnimalsCreated++;
        }


        /// <summary>
        /// Method to print out animal information
        /// </summary>
        /// <returns>String of information</returns>
        public override string ToString()
        {
            string strOut = string.Format("{0, -15} {1, 6}\n{2, -15} {3, 6}\n{4, -15} {5,6}\n",
                "ID", id, "Name: ", name, "Age", age);
            strOut += string.Format("{0, -15} {1, 6}\n{2, -15} {3, 6}\n{4, -15} {5,6}\n",
                "Gender: ", gender.ToString(), "Category: ", category.ToString(), "Description: ", description);
            return strOut;
        }

        /// <summary>
        /// Method to return information about animal
        /// </summary>
        /// <returns>String of information</returns>
        public virtual string GetExtraInfo() {
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