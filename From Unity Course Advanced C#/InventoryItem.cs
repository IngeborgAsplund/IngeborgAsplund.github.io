using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public enum ITEMTYPE {SPHERE,BOX,CYLINDER}
    public ITEMTYPE type;
    public Sprite icon = null;
    
    /// <summary>
    /// Similar to how list items in the courses at malmö university this is mailnly a  description of an object that can be added to a list/library
    /// alongside ínfo about the graphics we wish to represent the item with and a function that collects said item when an object tagged as player walks into it.
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player"))
            return;
        // add item
        Inventory.AddItem(gameObject);

    }

    
}
