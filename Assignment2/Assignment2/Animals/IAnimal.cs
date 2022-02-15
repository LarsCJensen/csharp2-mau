using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Animals
{
    interface IAnimal
    {
        string Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        GenderType Gender { get; set; }
        AnimalCategoryEnum Category { get; set; }
        string Description { get; set; }
        string GetExtraInfo();
    }
}
