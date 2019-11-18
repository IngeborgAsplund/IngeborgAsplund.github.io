using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//By Ingeborg Asplund 2018

namespace APUsZoo
{
    /// <summary>
    /// This is a general utility class that is used to serialize and deserialize files used in the apus zoo application
    /// It contains methods to read and write datastreams in binary streams.
    /// </summary>
    public static class BinSerializerUtility
    {
        /// <summary>
        /// This is a basic method for serializing a list of objects marked as serializable in general.
        /// it takes a list of objects and writes it down into a file on desk. It is highly adaptable and can therefore
        /// be used to serialize any list of objects marked as serializable
        /// </summary>
        /// <param name="serializedList"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static void BinaryFileSerList<T>(List<T> serializedList, string filename)
        {
            using (Stream str = new FileStream(filename, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(str, serializedList);
            }
            
            
        }
        /// <summary>
        /// General method for deserialize binary files, checking for that the files in question does exist 
        /// before opening them hindering craches due to user trying to open files that are faulty or do not exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static T BinaryFileDeSerialize<T>(string filepath)
        {
          
            using (Stream str = new FileStream(filepath, FileMode.Open))// open the selected file
            {
                BinaryFormatter bin = new BinaryFormatter();//create new binaryFormatter
                return (T)bin.Deserialize(str);// return the deserialized file
            }
            
        }
       
    }
}
