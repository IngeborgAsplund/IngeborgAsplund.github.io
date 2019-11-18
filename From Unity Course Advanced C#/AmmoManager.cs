using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject amunitionPrefab = null;
    //how much ammo is we supposed to have
    public int poolsize = 100;
    //array to put all the ammo in
    private GameObject[] ammoPool;
    // Singelton object first instanciated as null. There has to be only one of these in the scene.
    public static AmmoManager ammoManagerSingelton = null;

    public Queue<Transform> ammoQeue = new Queue<Transform>();
    void Awake()
    {
        if (ammoManagerSingelton != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        ammoManagerSingelton = this;
    }
    private void Start()
    {
        ammoPool = new GameObject[poolsize];
        for (int i = 0; i < poolsize; i++)
        {
            ammoPool[i] = Instantiate(amunitionPrefab,Vector3.zero,Quaternion.identity)as GameObject;
            Transform ammotrans = ammoPool[i].GetComponent<Transform>();
            ammotrans.parent = transform;
            ammoQeue.Enqueue(ammotrans);
            ammoPool[i].SetActive(false);
        }
    }
    /// <summary>
    /// Function that takes the last object in the ammoqeue, set it active and places it at the position and rotation of the gun turret or any other weapon using amunition.
    /// After being set active and moved to the correct position the ammo object is sent back to the ammopool qeue at the last position
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public static Transform SpawnAmmo(Vector3 position, Quaternion rotation)
    {
        Transform spawnedAmmo = ammoManagerSingelton.ammoQeue.Dequeue();
        spawnedAmmo.gameObject.SetActive(true);
        spawnedAmmo.position = position;
        spawnedAmmo.rotation = rotation;
        ammoManagerSingelton.ammoQeue.Enqueue(spawnedAmmo);

        return spawnedAmmo;

    }
}
