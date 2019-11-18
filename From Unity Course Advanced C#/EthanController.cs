using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class EthanController : MonoBehaviour
{

    private Animator ethanAnim = null;
    //Hash values
    private int verticalHash = Animator.StringToHash("Vertical");
    private int horizontalHash = Animator.StringToHash("Horizontal");

    void Awake()
    {
        ethanAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        ethanAnim.SetFloat(horizontalHash, horiz,0.1f,Time.deltaTime);
        ethanAnim.SetFloat(verticalHash, vert,0.1f,Time.deltaTime);
    }
}
