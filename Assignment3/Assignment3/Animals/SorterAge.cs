using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    class SorterAge : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
