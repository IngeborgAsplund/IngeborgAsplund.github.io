using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSight : MonoBehaviour
{
    //used to deside the area in which the enemy character can see the player.
    public enum Sensitivity { Strict,Loose}
    public Sensitivity senitiviity = Sensitivity.Strict;
    public float fieldOfView = 45f;  
    // which target are we looking after
    public Transform Target = null;
    //from which point are we looking(uses separate object but could be using a calculation with offset value from characters feet too)
    public Transform EyePoint = null;
    // bool determining if we can see the player character.
    public bool canSeeTarget = false;
    private SphereCollider range = null;
    private Transform myTransform = null;    
    public Vector3 lastSpottedPosition;// savse the postion where the player was last seen
    private void Awake()
    {
        range = GetComponent<SphereCollider>();// get sphere collider
        myTransform = GetComponent<Transform>();// get the transform component of the ai
        lastSpottedPosition = myTransform.position;// fill the last spotted position with the value of the own transform.position.
    }
   
    private void OnTriggerStay(Collider other)
    {
        UpdateSight();
        ///as long as we can se the player the last spotted position will be updated
        if (canSeeTarget)
        {
            lastSpottedPosition = Target.position;
        }
    }
    /// <summary>
    /// Bool determining if the player is in the field of biew of the npc this will be called when the player can possibly be seen by the NPC.
    /// </summary>
    /// <returns></returns>
    private bool IFOV()
    {
        //direction vector taking the distance between the eyepoint and the target.
        Vector3 directionToTarget = Target.position - EyePoint.position;
        // using the vector3. angle function to calculate the angle between the eyepoints forward vector and the above calculated angle.
        float angle = Vector3.Angle(EyePoint.forward, directionToTarget);
        //if angle is in inside the field of view return true
        if (angle <= fieldOfView)
            return true;
        //else return false.
        return false;
    }
    private bool ClearLineOfSight()
    {
        RaycastHit info;
        //casting a ray from the eyepoint to the player character the ray cannot go further than the line of sight collider cols radius
        if(Physics.Raycast(EyePoint.position,(Target.position-EyePoint.position).normalized,out info, range.radius))
        {
            if (info.transform.CompareTag("Player"))
                return true;
        }
        return false;
    }
    /// <summary>
    /// In this function we update the cansetarget bool based on which restriction the enemy has for seeing. To have two different states an enemy can be in 
    /// regarding the strictness of their sight can come in handy when creating ai. For instance there might be an enemy that do not see normlly say
    /// a robot using echolocation which would only require one of the conditions to be true to see the player
    /// </summary>
    private void UpdateSight()
    {
        switch (senitiviity)
        {
            case Sensitivity.Strict:
                canSeeTarget = IFOV() && ClearLineOfSight();// if we are strict about where the npc can see the player must be both in line of sight and inside the field of view of the npc
                return;
            case Sensitivity.Loose:// with a looser aproach the npc can se the player if any of the condtions are true
                canSeeTarget = IFOV() || ClearLineOfSight();
                return;
        }
    }
}
