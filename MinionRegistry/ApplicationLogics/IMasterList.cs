using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund
namespace ApplicationLogics
{
    /// <summary>
    /// Interface thought to work togheter with the generic list of the 
    /// </summary>
    public interface IMasterList<T>
    {
        /// <summary>
        /// Inheriting classes must inherit thismust implement this property which return the lenght of the current list
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Requirement to contain a function for adding an item to the list
        /// </summary>
        /// <param name="type"></param>
        void AddItem(T type);
        /// <summary>
        /// Recuirement to contain a funtion that deletes a specific item from a list
        /// </summary>
        /// <param name="i"></param>
        void DeleteItem(int i); 
        /// <summary>
        /// Requirement to include function to save binary files
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool SaveBinary(string path);
        /// <summary>
        /// Requirement to include function to load binary file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool LoadBinary(string path);
        
    }
}
