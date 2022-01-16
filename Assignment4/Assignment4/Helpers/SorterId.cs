using System;
using System.Collections.Generic;
using Assignment4.Animals;

namespace Assignment4.Helpers
{
    class SorterId : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}
