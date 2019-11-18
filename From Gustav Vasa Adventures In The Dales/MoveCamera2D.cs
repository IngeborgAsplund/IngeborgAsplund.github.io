using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// code to move the camera with the character
/// </summary>
public class MoveCamera2D : MonoBehaviour {
    //Instance variable
    private GameObject player;// reference to the player
    private bool panning;
    /// <summary>
    /// These two float values assigns where the camera can move, only if the cameras position is inside the allowed space it is allowed to move
    /// </summary>
    [SerializeField]
    private float maxMovement;
    [SerializeField]
    private float minMovement;
	// properties
    /// <summary>
    /// bool that looks for if the camera shall move with Gustav Vasa or not
    /// </summary>
    public bool MoveCamera
    {
        get { return panning; }
        set { panning = value; }
    }   
    private void Awake()
    {
        GameManager.managerWasa.IAmaCamera(GetComponent<Camera>());       
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    /// <summary>
    /// Function that moves the camera with the player
    /// </summary>
    public void  MoveMainCamera()
    {
        if (panning&&player.transform.position.x>minMovement&&player.transform.position.x<maxMovement)
        {
            transform.position = new Vector3(player.transform.position.x -1.5f, this.gameObject.transform.position.y, -9.38f);
        }
    }
    
}
