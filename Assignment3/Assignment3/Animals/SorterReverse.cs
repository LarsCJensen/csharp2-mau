using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    /// <summary>
    /// Generic class for sorting in reverse order
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SorterReverse<T>: IComparer<T>
    {
        public static readonly SorterReverse<T> Default = new SorterReverse<T>(Comparer<T>.Default);

        public static SorterReverse<T> Reverse(IComparer<T> comparer)
        {
            return new SorterReverse<T>(comparer);
        }

        private readonly IComparer<T> comparer = Default;

        public SorterReverse(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return comparer.Compare(y, x);
        }
    }
}
