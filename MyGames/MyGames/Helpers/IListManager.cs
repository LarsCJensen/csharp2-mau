using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGames.Helpers
{
    /// <summary>
    /// Interface for List manager
    /// </summary>
    /// <typeparam name="T">Type to create for</typeparam>
    public interface IListManager<T>
    {
        void SortList(IComparer<T> sorter, bool desc);
    }
}
