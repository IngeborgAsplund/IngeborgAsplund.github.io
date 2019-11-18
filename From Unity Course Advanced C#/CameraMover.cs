using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// camera class that uses translation of rotation and position of the camera object to make the camera follow the player object througout the scene
/// It utilises what was learned earlier in this course to make the camera track the player object
/// </summary>
public class CameraMover : MonoBehaviour
{
    private Transform camTransform = null;
    public Transform player = null;
    public float camRot = 90f;
    public float damping = 2f;
    public float distanceToPlayer = 12f;// This is the distance that we will keep to our player object while moving in the scene  
    void Awake()
    {
        camTransform = GetComponent<Transform>();
    }

    private void CameraMovement()
    {
        //rotate so that you are always looking at the player character no matter his rotation
        Quaternion destination = Quaternion.LookRotation(player.position - camTransform.position, Vector3.up);
        Quaternion cameraRotation = Quaternion.Slerp(camTransform.rotation, destination, camRot-(Time.deltaTime*damping));
        camTransform.rotation = cameraRotation;
        Vector3 campos = camTransform.position;
        campos.x = player.transform.position.x;
        campos.z = player.transform.position.z-2;
        //raycasthit variable for the camera
        RaycastHit camHit;
        if(Physics.Raycast(camTransform.position,-Vector3.up,out camHit))
        {
            
            campos.y = (camHit.point + Vector3.up * distanceToPlayer).y;
            
        }
        camTransform.position = campos;
       

    }
    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }
}
