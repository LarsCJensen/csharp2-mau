using System.Collections.Generic;
using Assignment4.Animals;

namespace Assignment4.Helpers
{
    class SorterGender: IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            return x.Gender.ToString().CompareTo(y.Gender.ToString());
        }
    }
}
