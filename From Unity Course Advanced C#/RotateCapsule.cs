using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCapsule : MonoBehaviour
{
    private Transform thisTransform = null;
    public float rotationSpeed = 90f;
    public float damping = 2f;

    public Transform targetTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }
    // Use a set speed to rotate around the objects own y axis. Selfrotation can be applied to any of an obects internal rotational axes
    private void RotateSelf()
    {
        thisTransform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);
    }
    // Rotation relative to the position of another object this is useful for targeting say the player in a shooter game.
    private void TrackObjects()
    {
        thisTransform.rotation = Quaternion.LookRotation(targetTransform.position - thisTransform.position, Vector3.up);
    }
    /// <summary>
    /// Tracks a target at a certain movement speed, the rotate towards property of quarternions is used here to create a more realistic
    /// tracking of say a player character in which the rotatingobject lags a bit behind creating a slower turn.
    /// </summary>
    private void TrackTargetOverTime()
    {
        Quaternion destRot = Quaternion.LookRotation(targetTransform.position - thisTransform.position, Vector3.up);
        thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, destRot, rotationSpeed * Time.deltaTime);
    }
    private void TrackTargetWithDamp()
    {
        Quaternion destRot = Quaternion.LookRotation(targetTransform.position-thisTransform.position, Vector3.up);
        Quaternion smothrot = Quaternion.Slerp(thisTransform.rotation, destRot, rotationSpeed - (Time.deltaTime * damping));
        thisTransform.rotation = smothrot;
    }
    void Update()
    {
        //TrackTargetOverTime();     
        TrackTargetWithDamp();
    }
}
