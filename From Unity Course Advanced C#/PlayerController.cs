using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{   
    private Transform playerTransform;
    private CharacterController myControl = null;
    public float movementSpeed = 10f;
    public float rotationSpeed = 5;
    public float jumpForce = 5f;
    public float groundedDistance = 10f;
    public bool isGrounded = false;
    private Vector3 velocity = Vector3.zero;
    public LayerMask groundLayer;
    // Awake Initializes all of the variables needed for the script to work
    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        myControl = GetComponent<CharacterController>();
    }
    /// <summary>
    /// Simple movement via the character controller
    /// </summary>
    private void simplyMove()
    {
        //get input axis for movement 
        float horiz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        //rotate player via quarternion multiplication
        playerTransform.rotation *= Quaternion.Euler(0f, rotationSpeed * horiz * Time.deltaTime, 0f);
        //Change player postiopn
        //playerTransform.position += playerTransform.forward * movementSpeed * vert * Time.deltaTime;
        myControl.SimpleMove(playerTransform.forward * movementSpeed * vert);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get input axis for movement 
        float horiz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        //rotate player via quarternion multiplication
        playerTransform.rotation *= Quaternion.Euler(0f, rotationSpeed *horiz* Time.deltaTime, 0f);
        // local space transformation below
        velocity.z = vert * movementSpeed;// local vector for movement 
        if (DistanceToGround() <= groundedDistance)
            isGrounded = true;
        else
            isGrounded = false;
        //check if the player is jumping
        if (CrossPlatformInputManager.GetAxisRaw("Jump") != 0 && isGrounded)       
            velocity.y = jumpForce;
    
        velocity.y += Physics.gravity.y * Time.deltaTime;// apply force to the player in order to land

        myControl.Move(playerTransform.TransformDirection(velocity) * Time.deltaTime);
        
    }
    /// <summary>
    /// Custom function that describes weather or not we are touching the ground. This is continuosly called once per frame in the fixed update function
    /// </summary>
    /// <returns></returns>
    public float DistanceToGround()
    {
        RaycastHit h;
        float distanceToGround = 0;
        if (Physics.Raycast(playerTransform.position, -Vector3.up, out h, Mathf.Infinity, groundLayer))
            distanceToGround = h.distance;
        return distanceToGround;
    }
}
