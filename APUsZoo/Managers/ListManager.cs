using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// <summary>
/// Generic class for handling many different types of lists of different objects, such as animals, employees, strings, foodrecipes and similar
/// All wrapper classes Ie classes containing lists of obejects or variable types in APU zoo inhertis this class as well as implements its functions.
/// This is also true for the code running behind the scenes of the employer and recipe forms respectively.
/// </summary>
namespace APUsZoo
{
    [Serializable]
    public class ListManager<T>:IListManager<T> 
    {       
        protected List<T> adaptableList;
        /// <summary>
        /// BaseConstructor
        /// </summary>
        public ListManager()
        {
            adaptableList = new List<T>();
        }
        /// <summary>
        /// Constructor that returns the lenght of the generic list
        /// </summary>
        public int Count
        {
            get { return adaptableList.Count; }
        }
       
        
        /// <summary>
        /// Function to add things to the list, it is written as a virtual method so that underlying classes easiyl can adapt it in their own way
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public  bool Add(T type)
        {
            bool added = false;
            if (type != null)
            {
                added = true;
            }
            if (added)
            {
                adaptableList.Add(type);
            }
            return added;
        }
        /// <summary>
        /// Simple validation method used for validating indexes 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public  bool ValidateIndex(int index)
        {
            bool valid = false;
            if(index!=-1)
            {
                valid = true;
            }
            return valid;
        }
        /// <summary>
        /// Function to change objects in the list it first checks so that the object it want to change into is not null
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public  bool Change(T type, int index)
        {
            bool changed = false;
            bool indexValid = ValidateIndex(index);
            if (indexValid&&type!=null)
                changed = true;
            if (changed)
            {
                adaptableList.RemoveAt(index);
                adaptableList.Insert(index, type);
            }
            return changed;
        }
        /// <summary>
        /// Function to delete an object from the list, this do not need to be virtual
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Delete(int index)
        {
            bool deleted = false;
            bool validate = ValidateIndex(index);
            if (validate)
                deleted = true;
            if (deleted)
            {
                adaptableList.RemoveAt(index);
            }
            return deleted;
        }
        /// <summary>
        /// Function to delete an item from the list, may be called by a reset function in main form when the user chooses new as an option
        /// Looks the same for all lists and are therefore not coded virtual.
        /// </summary>
        public void DeleteAll()
        {
            adaptableList.Clear();
        }
        /// <summary>
        /// Function that is used to find an item at the list with the help of an integer representing the position in the list
        /// By superstrange reasons it does not work and does allways return an out of index exeption when run altogh it usually returns a value when used in a normal non-generic context
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T FindAt(int index)
        {      
            T mytype = adaptableList.ElementAt(index);
            return mytype;                      
        }
        /// <summary>
        /// Function that displays a list of objects as strings called by GUI Methods        
        /// </summary>
        /// <returns></returns>
        public string[] PresentArray()
        {
            string[] stringAarray = new string[Count];
            int index = 0; 
                foreach (T type in adaptableList)
                {
                    stringAarray[index] = adaptableList[index].ToString();
                    index++;
                }
           return stringAarray;
        }
        /// <summary>
        /// Function that puts out a list of strings rather than an array of strings, may be used for simpler GUI Managers.
        /// I prefer to use the array version but think this might be useful when we are not handling lists of less complex objec types
        /// </summary>
        /// <returns></returns>
        public List<string> PresentStringList()
        {
           List<string> presentationLines = new List<string>();
            foreach(T type in adaptableList)
            {
                presentationLines.Add(type.ToString());//adds a string/ format animal details to the list 
            }
            return presentationLines;
        }
        /// <summary>
        /// Serializes the data in the list 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool BinarySerialize(string fileName)
        {
            bool sucess = false;
            if (!string.IsNullOrEmpty(fileName))// first we check so that the fileName is not empty or null
                sucess = true;
            if(sucess)
            {
                BinSerializerUtility.BinaryFileSerList(adaptableList, fileName);// drive the method in the utility class
            }
            return sucess;
        }
        /// <summary>
        /// DeSerialize data in binary form adding it to the list that implements/ calls it
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool BinaryDeSerialize(string fileName)
        {
            bool sucess = false;
            if (!string.IsNullOrEmpty(fileName))// if the file has a name we count it as sucess
                sucess = true;
            if (sucess)// if we have sucess
            {
                adaptableList = BinSerializerUtility.BinaryFileDeSerialize<List<T>>(fileName);// load in the earlier serialized list into the application
            }
            return sucess;
        }
        /// <summary>
        /// Serialize a list of data into an xmlfile
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool XMlSerialization(string fileName)
        {
            bool sucess = false;
            if (!string.IsNullOrEmpty(fileName))// does the file have proper naming?
                sucess = true;// if so sucess is true
            if(sucess)
            {
                XMLSerializerUtility.XMLSerialize<T>(fileName,adaptableList);// call xmlserializermethod from utility classes
            }
            return sucess;
        }
        /// <summary>
        /// Deserialize data from an xmlfile saved from the application
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool XMLDeserialization(string fileName)
        {
            bool sucess = false;
            if (!string.IsNullOrEmpty(fileName))
            {
                adaptableList = XMLSerializerUtility.XMlFileDeserializer<List<T>>(fileName);
            }
            return sucess;
        }
        /// <summary>
        /// Method that sorts the animals in the zooregistry by either their name or theri ID(generic list.sort(Animal.ID)).
        /// It will be called by main form each time it updates the list of animals in lstanimalist
        /// </summary>
        public void Sort(IComparer<T> comparer)
        {
            adaptableList.Sort(comparer);
        }
        /// <summary>
        /// The below method drives the lokal generate foodschedule methods from within the specific animal objects based on their specie.
        /// It take an animal as a parameter(obviosly the recently added one) and search for the speciename within the animal object 
        /// Switch case can be expanded on later when more species are added
        /// </summary>
        public void GenerateFoodSchedule(T anim)
        {
            string specie = (anim as Animal).GetSpecies();// get the name of the specie
            FoodSchedule schedule = new FoodSchedule();// create new object of foodschedule type
            switch (specie)// runs a switch statement based on the string for speciename
            {
                case "Chameleon":
                    (anim as Chameleon).GetFoodschedule();
                    break;
                case "Sea Turtle":
                    (anim as SeaTurtle).GetFoodschedule();
                    break;
                case "Pigeon":
                    (anim as Pigeon).GetFoodschedule();
                    break;
                case "Parrot":
                    (anim as Parrot).GetFoodschedule();
                    break;
            }
        }
    }

}
