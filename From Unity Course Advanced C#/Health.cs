using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float healthPoints = 100;

    /// <summary>
    /// acess to the healthpoints is achieved through the set functionality of this property that also determines weather or not the player
    /// should die or not. If so the player object is destroyed(Ideally he is respawned on the last saved position or on a specific save spot.)
    /// </summary>
    public float HealthPoints
    {
        get { return healthPoints; }
        set
        {
            healthPoints = value;
            if (healthPoints <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
