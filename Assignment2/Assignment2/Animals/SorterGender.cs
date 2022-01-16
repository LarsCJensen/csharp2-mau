using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Animals
{
    class SorterGender: IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return x.Gender.ToString().CompareTo(y.Gender.ToString());
        }
    }
}
