using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Transform turretTransform = null;
  /// <summary>
  /// It is in general better to use the awake function to initiate since it by all guarantees is qued before everything else is run,
  /// the start function might be called after the call for the objects needing to instanciate which causes errors
  /// </summary>
    void Awake()
    {
        turretTransform = GetComponent<Transform>();
    }
    /// <summary>
    /// Observe that code is not written directly in update but is called through functions later in the script
    /// </summary>
    void Update()
    {
        TrackMousePos();
    }
    private void TrackMousePos()
    {
        //vector3 describing the position of the mouse cursor
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                                       Input.mousePosition.y, 0));      
        mousePosWorld = new Vector3(mousePosWorld.x,turretTransform.position.y, mousePosWorld.z);
        // vector describing how we should be looking using the difference between mouseposition and our current position
        Vector3 lookDirection = mousePosWorld - turretTransform.position;
        ///set the local rotation of the turret object to the lookrotation of lookdirection.normalized to rotate around our up vector.
        turretTransform.localRotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
    }
   
}
