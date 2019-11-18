using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
//By Ingeborg Asplund 2018
namespace ApplicationLogics
{
    /// <summary>
    /// class that contains all of the logics needed by the lists in this application.
    /// </summary>
    /// 
    [Serializable]
    public class MasterList<T>:IMasterList<T>
    {
        protected List<T> genericList;
        /// <summary>
        /// constructor for the class
        /// </summary>
        public MasterList()
        {
            genericList = new List<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        public List<T> Mylist { get { return genericList; } }
        /// <summary>
        /// property for the number of items on the list
        /// </summary>
        public int Count { get { return genericList.Count; } }
        /// <summary>
        /// Function for adding to the list
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(T item)
        {
            if (item != null)
                genericList.Add(item);
        }
        /// <summary>
        /// Function for deleting from the list
        /// </summary>
        /// <param name="i"></param>
        public void DeleteItem(int i)
        {
            if (i != -1)
                genericList.RemoveAt(i);
        }
        public bool SaveBinary(string path)
        {
            bool sucess = false;
            if (!string.IsNullOrEmpty(path))
                sucess = true;                           
            if (sucess)
                BinarySerialize.BinarySave(genericList, path);
            
            return sucess;
        }
        public bool LoadBinary(string path)
        {
            bool sucess = false;
            if (!string.IsNullOrEmpty(path))
                genericList = BinarySerialize.BinaryLoad<List<T>>(path);

            return sucess;
        }
        
       

    }
}
