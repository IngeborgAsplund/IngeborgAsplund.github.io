using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// System for saving and loading the game 
/// </summary>
public static class SaveAndLoad
{
    
    /// <summary>
    /// This Method serializes the data inside of the Respawnistance class to a binary file taking in the variables and saves them down to a binary file
    /// in the default save directory for unity games
    /// </summary>
	public static void SerializeGameData(RepawnInsans indata)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GustavWasa.save";

        FileStream stream = new FileStream(path,FileMode.Create);
        
        formatter.Serialize(stream,indata);//serialize the data inside the respawninstance
        stream.Close();       
    }
    /// <summary>
    /// This method deserializes a binary file back to a respawninstance object checking that the file in question does exist before opening the filestream.
    /// </summary>
    /// <returns></returns>
    public static RepawnInsans LoadGameData()
    {
        string path = Application.persistentDataPath + "/GustavWasa.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Debug.Log(path);
            RepawnInsans load = formatter.Deserialize(stream) as RepawnInsans;
            stream.Close();
            return load;
        }
        else
        {
            Debug.LogError("No existíng save file was found at" + path);
            return null;
        }
        
    }
}
