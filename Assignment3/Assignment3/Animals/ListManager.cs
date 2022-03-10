using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Animals
{
    public class ListManager<T> : IListManager<T>
    {
        private List<T> m_List = new List<T>();
        /// <summary>
        /// Number of animals in list
        /// </summary>
        /// <returns>Number of animals in list</returns>
        public int Count 
        {
            get
            {
                return m_List.Count();            
            }
        }
           
        public bool Add(T type)
        {
            if(type != null)
            {
                m_List.Add(type);
                return true;
            }
            return false;
        }

        public bool Edit(T type, int index)
        {
            if(type != null)
            {
                m_List[index] = type;
                return true;
            }
            return false;
        }

        public bool CheckIndex(int index)
        {
            throw new NotImplementedException();
        }
        
        public void DeleteAll()
        {
            m_List.Clear();
        }

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
        /// Get animal at a certain index
        /// </summary>
        /// <param name="index">Index number</param>
        /// <returns>Animal at intex</returns>
        public T GetAt(int index)
        {
            return m_List[index];
        }
        /// <summary>
        /// Gets all strings for T
        /// </summary>
        /// <returns></returns>
        public string[] ToStringArray()
        {
            // TODO Break out to helper function
            string[] infoStrings = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                infoStrings[i] = GetAt(i).ToString();
            }
            return infoStrings;
        }

        public List<string> ToStringList()
        {
            // TODO Break out to helper function
            List<string> infoStrings = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                infoStrings.Add(GetAt(i).ToString());
            }
            return infoStrings;
        }


        // TODO REMOVE
        private void ArrangeObjects(int removedIndex)
        {
            // If this is run each time a recipe is deleted and because you only can select one item
            // then it shouldn't need to loop over all items and setting them to null. But this solution will be 
            // future proff if multi-select is introduced.
            for (int i = removedIndex+1; i <= m_List.Count; i++)
            {
                m_List[i - 1] = m_List[i];
                m_List[i] = default(T);
            }
        }

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
