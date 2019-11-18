using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float lifeTime = 2f;

    /// <summary>
    /// When the amunition object is instanciated it invokes a death/destroy function that set the object inactive after a certain amount of time.
    /// </summary>
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die",lifeTime);
    }
    /// <summary>
    /// Function that set the amunition object inactive after its lifespan has ended.
    /// </summary>
    private void Die()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
}
