using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    /// <summary>
    /// Generic manager for lists
    /// </summary>
    /// <typeparam name="T">Type for list</typeparam>
    public class ListManager<T> : IListManager<T>
    {
        private List<T> m_List = new List<T>();
        /// <summary>
        /// Number of objects in list
        /// </summary>
        /// <returns>Number of objects in list</returns>
        public int Count 
        {
            get
            {
                return m_List.Count();            
            }
        }
        
        /// <summary>
        /// Add to list
        /// </summary>
        /// <param name="type">Type to add</param>
        /// <returns>bool</returns>
        public bool Add(T type)
        {
            if(type != null)
            {
                m_List.Add(type);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Edit list item
        /// </summary>
        /// <param name="type">Type of object</param>
        /// <param name="index">Index of object</param>
        /// <returns>bool</returns>
        public bool Edit(T type, int index)
        {
            if(type != null)
            {
                m_List[index] = type;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if index is available
        /// </summary>
        /// <param name="index">Index to check</param>
        /// <returns>bool</returns>
        public bool CheckIndex(int index)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete all objects from list
        /// </summary>
        public void DeleteAll()
        {
            m_List.Clear();
        }
        /// <summary>
        /// Delete list item
        /// </summary>
        /// <param name="index">Index to delete</param>
        /// <returns>bool</returns>
        public bool Delete(int index)
        {
            if(m_List[index] != null)
            {
                m_List.RemoveAt(index);                
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get object at a certain index
        /// </summary>
        /// <param name="index">Index number</param>
        /// <returns>Object at intex</returns>
        public T GetAt(int index)
        {
            return m_List[index];
        }
        /// <summary>
        /// Gets all strings for T
        /// </summary>
        /// <returns>Array of strings</returns>
        public string[] ToStringArray()
        {
            string[] infoStrings = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                infoStrings[i] = GetAt(i).ToString();
            }
            return infoStrings;
        }
        /// <summary>
        /// Get strings of all items in list
        /// </summary>
        /// <returns>List of strings</returns>
        public List<string> ToStringList()
        {
            List<string> infoStrings = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                infoStrings.Add(GetAt(i).ToString());
            }
            return infoStrings;
        }
        /// <summary>
        /// Sorter function for list
        /// </summary>
        /// <param name="sorter">Type of sorter</param>
        /// <param name="desc">If descending order</param>
        public void SortList(IComparer<T> sorter, bool desc)
        {            
            if (desc)
            {
                m_List.Sort(new SorterReverse<T>(sorter));
            }
            else
            {
                m_List.Sort(sorter);
            }
        }
    }
}
