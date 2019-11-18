using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleClicks : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData click)
    {
        Debug.Log("You clicked: " + click.pointerPress.name);
    }
}
