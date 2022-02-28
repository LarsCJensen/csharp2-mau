using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Class to manage animal objects
    /// </summary>
    public class AnimalManager
    {
        private List<Animal> animalList = new List<Animal>();
        //public List<Animal> AnimalList
        //{
        //    get
        //    {
        //        return animalList;
        //    }
        //}

        private int startId = 1000;
        public AnimalManager()
        {

        }
        /// <summary>
        /// Add an animal to list
        /// </summary>
        /// <param name="animal">Animal to add</param>
        /// <returns>If succeeded</returns>
        public bool Add(Animal animal)
        {
            if (animal != null)
            {
                startId = startId += 1;
                switch (animal.Category)
                {
                    case AnimalCategoryEnum.Mammals:
                        animal.Id = $"M{startId}";
                        break;
                    case AnimalCategoryEnum.Birds:
                        animal.Id = $"B{startId}";
                        break;
                    case AnimalCategoryEnum.Insects:
                        animal.Id = $"I{startId}";
                        break;
                    case AnimalCategoryEnum.Reptiles:
                        animal.Id = $"R{startId}";
                        break;
                    default:
                        animal.Id = $"{startId}";
                        break;
                }
                animalList.Add(animal);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Number of animals in list
        /// </summary>
        /// <returns>Number of animals in list</returns>
        public int Count()
        {
            return animalList.Count();
        }
        /// <summary>
        /// Get animal at a certain index
        /// </summary>
        /// <param name="index">Index number</param>
        /// <returns>Animal at intex</returns>
        public Animal GetAnimalAt(int index)
        {
            return animalList[index];
        }
        /// <summary>
        /// Gets all strings for animal
        /// </summary>
        /// <returns></returns>
        public string[] GetAnimalInfoStrings()
        {
            string[] infoStrings = new string[Count()];
            for(int i = 0; i < Count(); i++)
            {
                infoStrings[i] = GetAnimalAt(i).ToString();
            }
            return infoStrings;
        }        
        public void SortAnimalList(string sortColumn, bool sortDescending)
        {
            switch (sortColumn)
            {
                case "Age":
                    // Sort by age
                    if (sortDescending)
                    {
                        animalList.Sort((Animal x, Animal y) =>
                        y.Age.CompareTo(x.Age));
                    }
                    else
                    {
                        animalList.Sort((Animal x, Animal y) =>
                        x.Age.CompareTo(y.Age));
                    }

                    break;
                case "ID":
                    // Sort by id
                    if (sortDescending)
                    {
                        animalList.Sort((Animal x, Animal y) =>
                            y.Id.CompareTo(x.Id));
                    }
                    else
                    {
                        animalList.Sort((Animal x, Animal y) =>
                        x.Id.CompareTo(y.Id));
                    }

                    break;
                case "Gender":
                    // Sort by gender
                    if (sortDescending)
                    {
                        animalList.Sort((Animal x, Animal y) =>
                        y.Gender.ToString().CompareTo(x.Gender.ToString()));
                    }
                    else
                    {
                        animalList.Sort((Animal x, Animal y) =>
                        x.Gender.ToString().CompareTo(y.Gender.ToString()));
                    }

                    break;
                default:
                    // Sort by name
                    if (sortDescending)
                    {
                        animalList.Sort((Animal x, Animal y) =>
                        y.Name.CompareTo(x.Name));
                    }
                    else
                    {
                        animalList.Sort();
                    }
                    break;
            }            
        }
    }
}
