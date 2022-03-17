using System;
using System.Collections.Generic;
using Assignment4.Animals;

namespace Assignment4.Helpers
{
    class SorterName : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
