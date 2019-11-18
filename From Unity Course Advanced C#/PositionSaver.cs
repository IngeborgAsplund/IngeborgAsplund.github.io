using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PositionSaver : MonoBehaviour
{
    public Vector3 lastPosition = Vector3.zero;//can be handled with the use of a property
    public Quaternion lastRotation = Quaternion.identity;// same as above
    private Transform playerTransform = null;// in a bigger game this should be found through the game manager
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GetComponent<Transform>();// in a bigger game playerTransform= gameManager.instance.Player.
    }
    /// <summary>
    /// function that save the players position as a JSONstring at this applications persistent datapath
    /// </summary>
    private void SaveObject()
    {
        string outPut = Application.persistentDataPath +@"\PlayerPosition.json";
        lastPosition = playerTransform.position;
        lastRotation = playerTransform.rotation;

        StreamWriter writer = new StreamWriter(outPut);
        writer.Write(JsonUtility.ToJson(this));
        writer.Close();
        Debug.Log("Outputting to " + outPut);
    }
    /// <summary>
    /// Function that loads the same JSONstring and reads its positions and rotation data to the player objects rotation and position data
    /// </summary>
    private void LoadObject()
    {
        if(File.Exists(Application.persistentDataPath + @"\PlayerPosition.json"))// this is an extra check that confirms that the loading of a players last position in a level only happens when the file containing said data does exist
        {
            string inputpath = Application.persistentDataPath + @"\PlayerPosition.json";
            StreamReader reader = new StreamReader(inputpath);
            string JSONString = reader.ReadToEnd();
            Debug.Log("Reading " + JSONString);
            JsonUtility.FromJsonOverwrite(JSONString, this);
            reader.Close();

            playerTransform.position = lastPosition;
            playerTransform.rotation = lastRotation;
        }
       
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        SaveObject();
    }
    private void Start()
    {
        LoadObject();
    }
   

}
