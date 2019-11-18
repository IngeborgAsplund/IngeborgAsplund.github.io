using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//By Ingeborg Asplund
namespace Utilities
{
    /// <summary>
    /// This class produces and reads binary files based of the objects in the minion registry.
    /// </summary>
    public static class BinarySerialize
    {
       /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="inlist"></param>
       /// <param name="fileName"></param>
        public static void BinarySave<T>(List<T> inlist,string fileName)
        {
            using (Stream str = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(str, inlist);
            }
        }
        public static T BinaryLoad<T>(string fileName)
        {
            using(Stream str = new FileStream(fileName, FileMode.Open)) 
            {
                BinaryFormatter bin = new BinaryFormatter();
                return (T)bin.Deserialize(str);
            }
        }
    }
}
