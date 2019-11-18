using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float maximumSpeed = 1f;
    private Transform thisTransform =null;
    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        thisTransform.position += thisTransform.forward * maximumSpeed*Time.deltaTime;
    }
}
