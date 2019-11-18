using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace APUsZoo
{
    /// <summary>
    /// Interface that defines the functionality of the generic class ListManager<T> as well as all classes that inherits from that class
    /// The methods required are loosly based on those already defined in the AnimalManager but contains a 
    /// </summary>
    public interface IListManager<T>
    {
        /// <summary>
        /// method that returns the lenght of the list
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Validation method for indexes, implemented with kewyword vitural in Listmanager and ovveride in deriving classes
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        bool ValidateIndex(int index);
        /// <summary>
        /// Add an item of a type specificed by the user script
        /// </summary>
        /// <param name="atype"></param>
        /// <returns></returns>
        bool Add(T atype);
        /// <summary>
        /// change an item at a spot in the registry, do not need to be used by all lists for now though they must all contain some type of implementation of this
        /// </summary>
        /// <param name="aType"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        bool Change(T aType, int index);
        /// <summary>
        /// Delete an item from the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        bool Delete(int index);
        /// <summary>
        /// Deletes all items on list
        /// </summary>
        void DeleteAll();
        /// <summary>
        /// Find an item at a specific index in the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T FindAt(int index);
        /// <summary>
        /// Present all items in the list as an array of strings(Implemented as a virtual as different lists may want to do this a bit differently)
        /// </summary>
        /// <returns></returns>
        string[] PresentArray();
        /// <summary>
        /// Returns a list of strings describing the objects in the list
        /// </summary>
        /// <returns></returns>
        List<string> PresentStringList();
        /// <summary>
        /// Method for serializing data contained in objects in the program
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool BinarySerialize(string fileName);
        /// <summary>
        /// Method for deserialize objects earlier serialized and saved to disk, helping to open old versions
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool BinaryDeSerialize(string fileName);
        /// <summary>
        /// Serializiation to XML format
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool XMlSerialization(string fileName);
        /// <summary>
        /// Method to deserialize xmlfiles selected from disc.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool XMLDeserialization(string fileName);
        /// <summary>
        /// Sorting method for sorting animals specificly
        /// </summary>
        /// <param name="comparer"></param>
        void Sort(IComparer<T> comparer);
        /// <summary>
        /// The foodschedule generation method
        /// </summary>
        /// <param name="anim"></param>
        void GenerateFoodSchedule(T anim);
        
    }
}
