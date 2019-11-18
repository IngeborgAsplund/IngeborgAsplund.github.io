using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TerraingMove : MonoBehaviour
{
    private Transform playerTransform = null;
    public float maxSpeed = 10f; //speed initially set to 10, this is how fast this object will move
    public float angularSpeed = 5f;
    public float distancetoTerrain = 2f;//this is the distance that we will keep to the terrain while flying
    private Vector3 destUP = Vector3.zero;// vector that is used to store 
    void Awake()
    {
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 newPos = playerTransform.position;
        newPos += playerTransform.forward * vert * maxSpeed * Time.deltaTime;//postioion transformed using worldspace.
        newPos += playerTransform.right * horiz * maxSpeed * Time.deltaTime;// similar movement to the above but to the sides
        RaycastHit groundHit;
        if(Physics.Raycast(playerTransform.position,-Vector3.up, out groundHit))//require parameters vector3 startposition, vector3 direction and an output vector3hit
        {
            newPos.y = (groundHit.point + Vector3.up * distancetoTerrain).y;
            destUP = groundHit.normal;
        }
        playerTransform.position = newPos;
        playerTransform.up = Vector3.Slerp(playerTransform.up, destUP, angularSpeed*Time.deltaTime);
        
    }
}
