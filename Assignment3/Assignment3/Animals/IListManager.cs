using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    /// <summary>
    /// TODO WRITE
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListManager<T>
    {
        int Count { get; }
        bool Add(T type);
        bool Edit(T type, int index);
        bool CheckIndex(int index);
        void DeleteAll();
        bool Delete(int index);
        T GetAt(int index);
        string[] ToStringArray();
        List<string> ToStringList();
        void SortList(IComparer<T> sorter, bool desc);
    }
}
