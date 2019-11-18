using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target = null;
    private Transform thisTransform = null;
    public Transform lineStart = null;
    public Transform lineEnd = null;
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //the line we should follow is calculated via subtracting startpoint from its endpoint
        Vector3 normal = (lineEnd.position - lineStart.position).normalized;
        //move me towards the position of the target along the earlier defined normalizedd line vector
        Vector3 pos = lineStart.position + Vector3.Project(target.position - lineStart.position, normal);

        //Clamping that dissalows the turret from leaving its track
        pos.x = Mathf.Clamp(pos.x, Mathf.Min(lineStart.position.x, lineEnd.position.x), Mathf.Max(lineStart.position.x, lineEnd.position.x));
        pos.y = Mathf.Clamp(pos.y, Mathf.Min(lineStart.position.y, lineEnd.position.y), Mathf.Max(lineStart.position.y, lineEnd.position.y));
        pos.z = Mathf.Clamp(pos.z, Mathf.Min(lineStart.position.z, lineEnd.position.z), Mathf.Max(lineStart.position.z, lineEnd.position.z));

        thisTransform.position = pos;
    }
}
