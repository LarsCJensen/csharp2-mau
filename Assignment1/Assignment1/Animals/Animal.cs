using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    public class Animal
    {
        /// <summary>
        /// Base class which holds general fields and methods for all animals
        /// </summary>
        /// 
        // Wanted to try to use a static field to check how many animals that have been created
        public static int NumberOfAnimalsCreated = 0;
        // Five attributes
        private static int idCounter = 1000;
        private int id;
        public int Id
        {
            // Only allowed to get
            get
            {
                return id;
            }
        }
        private string name = "";
        public string Name {
            get 
            {
                return name; 
            }
            set 
            {
                if(value.Length > 0)
                {
                    name = value;
                }
            }

        }
        private int age = 0;
        public int Age {
            get 
            {
                return age;
            } 
            set
            {
                if(value != 0)
                {
                    age = value;
                }
            } 
        }
        private GenderType gender = GenderType.Unknown;
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
        private string description = "";
        public string Description {
            get 
            {
                return description;
            } 
            set
            {
                if(value.Length > 0)
                {
                    description = value;
                }
            } 
        }

        public Animal(string animalName, int animalAge, GenderType animalGender, string animalDesc)
        {
            id = getId();
            name = animalName;
            age = animalAge;
            gender = animalGender;
            description = animalDesc;

            NumberOfAnimalsCreated++;
        }
        public List<string> ListAllAnimals()
        {
            // How to get all animals??
            List<string> animals = new List<string>();
            animals.Add("Test");
            return animals;
        }
        /// <summary>
        /// Perhaps overkill with a helper method for this, but it gives an abstraction in case we want to change how id's are set.
        /// </summary>
        /// <returns></returns>
        private int getId()
        {
            idCounter = idCounter += 1;
            return idCounter;
        }
    }
}