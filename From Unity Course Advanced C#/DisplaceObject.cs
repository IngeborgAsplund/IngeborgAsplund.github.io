using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float displaceSpeed = 2f;// the speed at which we are moving forward in.
    private Transform thisTransform = null; // the transform component of the object which are moved forward.

    [SerializeField]
    private Vector3 localForward;
    [SerializeField]
    private Vector3 globalForward;
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }
    private void DisplaceInWorldspace()
    {
        thisTransform.position += thisTransform.forward * displaceSpeed * Time.deltaTime; // movement in worldspace using the objects forward vector to move in the global spce of the scene
    }

    private void displaceInLocalSpace()
    {
        Vector3 localSpaceDisplacement = Vector3.forward * displaceSpeed * Time.deltaTime; // movement in localspace where the general forward vector are used to displace the object in the world.
        Vector3 worldSpaceDisplacement = thisTransform.TransformDirection(localSpaceDisplacement); // convert the localdisplacement vector defined above to be relative to the objects position in worldspace

        thisTransform.position += worldSpaceDisplacement;
    }
    // Update is called once per frame
    void Update()
    {
        localForward = Vector3.forward;// our local forward vector
        globalForward = thisTransform.forward;// vector describing the position of the object in worldspace

        Vector3 localSpaceDisplacement = Vector3.forward * displaceSpeed * Time.deltaTime; // movement in localspace where the general forward vector are used to displace the object
        Vector3 worldSpaceDisplacement = thisTransform.rotation * localSpaceDisplacement; // translating the above into worldspacemovement through multiplying it with the objects quarternion.rotation
        // the order of multiplication here matters and the quarternion needs to come first otherwise an error is prodced.

        thisTransform.position += worldSpaceDisplacement;
    }
}
