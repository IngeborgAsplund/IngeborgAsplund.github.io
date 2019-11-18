using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a script that controls certain object conditions connected to a specific npc. It could later be fleshed out to contain 
/// </summary>
public class NPCConditions : MonoBehaviour
{
    [SerializeField]
    Unlocker interactableItem;//item that we want to interact with after talking to this NPC

    /// <summary>
    /// Method for enabling Gustav to interact with an item 
    /// </summary>
    public void MakeInteractable()
    {
        interactableItem.Interactable = true;
    }
    /// <summary>
    /// Method for disabling the interactivity of objects
    /// </summary>
    public void ShutOffInteractability()
    {
        interactableItem.Interactable = false;
    }
}
