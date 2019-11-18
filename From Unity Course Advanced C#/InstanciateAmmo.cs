using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateAmmo : MonoBehaviour
{
    
    
    // Update is called once per frame
    void Update()
    {
        SpawnAmmo();
    }
    /// <summary>
    /// Function that instanciate the amunition prefab whenever the player press fire1
    /// </summary>
    private void SpawnAmmo()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate(ammunition, transform.position,transform.rotation);
            //we now go through the ammomanager instead of instanciating ammunition into the scene via this function.
            AmmoManager.SpawnAmmo(transform.position, transform.rotation);
        }
    }
}
