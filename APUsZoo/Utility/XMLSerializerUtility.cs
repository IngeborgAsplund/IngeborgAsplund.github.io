using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
//By Ingeborg Asplund 2018
/// <summary>
/// This is a general utility class for reading and writing xml files. It will be static 
/// </summary>
namespace APUsZoo
{
    public static class XMLSerializerUtility
    {
        /// <summary>
        /// General method to serialize data of a list of objects into xmlformat.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <param name="adaptableList"></param>
        public static void XMLSerialize<T>(string filepath, object list)
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<T>));//new xml serializer of type List<T>
            TextWriter write = new StreamWriter(filepath);// initiate a new texwriter using a streamwriter of the assigned filepath
            try
            {
                serial.Serialize(write,list);// try to serialize after the assigned filepath
            }
            finally
            {
                if (write != null) write.Close();
            }
        }
        /// <summary>
        /// General method for deserializing xmlfiles
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static T XMlFileDeserializer<T>(string filepath)
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<T>));// define a new deserializer of type list
            TextReader read = new StreamReader(filepath);// Defines textreader as new streamreader of the desired filepath
            try
            {
                return (T)serial.Deserialize(read);// try to return T as the content of textreader
            }
            finally
            {
                if (read != null) read.Close();
            }
        }
    }
}
