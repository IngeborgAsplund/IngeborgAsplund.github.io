using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class OrbitSphere : MonoBehaviour
{
    private Transform thisTransform = null;
    public Transform pivot = null;
    private Quaternion DestRot = Quaternion.identity;
    public float pivotDistance = 1.6f;
    public float rotSpeed = 90f;
    private float rotX = 0f;
    private float rotY = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        rotX += horiz *Time.deltaTime*rotSpeed;// continuosly calculate the value of the rotation along the x axis.
        rotY += vert * Time.deltaTime*rotSpeed;// continuosly calculate the value of the rotation around the y axis 
        ///Calcuate the destinaion rotation it is important to note that the order in wich the quarternions are multiplied matter since the result may differ if inverted.
        Quaternion yRot = Quaternion.Euler(0, rotY, 0);
        DestRot = yRot * Quaternion.Euler(rotX, 0, 0);

        thisTransform.rotation = DestRot;
        //Note that the pivotdistance is implemented as a negative this is because we want it to be offset away from the pivot object
        thisTransform.position = pivot.position + thisTransform.rotation * Vector3.forward * -pivotDistance;
        
    }
}
