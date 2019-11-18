using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// the inventory is coded as a singelton item meaning that there can not be more than one of this object in the scene as we do not want
    /// the player to get more than one inventory.
    /// </summary>
    public static Inventory Instance
    {
        get
        {
            if(ThisInstance == null)
            {
                GameObject InventoryObject = new GameObject("Inventory");
                ThisInstance = InventoryObject.AddComponent<Inventory>();
            }
            return Instance;
        }
    }
    private static Inventory ThisInstance = null;

    public RectTransform ItemList = null;
    /// <summary>
    /// Here we check if there are already an object of type inventory and if so destroys this instance of the same object thus hidering two interfaces from appearing at the same time
    /// </summary>
    private void Awake()
    {
        if (ThisInstance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        ThisInstance = this;
    }
    public static void AddItem( GameObject obj)
    {
        //disabel all colliders for the object
        foreach(Collider c in obj.GetComponents<Collider>())
        {
            c.enabled = false;
        }
        //disabel all meshrenderers for the object
        foreach(MeshRenderer mr in obj.GetComponents<MeshRenderer>())
        {
            mr.enabled = false;
        }
        // find the first unocupied slot in the inventory gui 
        for(int i = 0; i < ThisInstance.ItemList.childCount; i++)
        {
            Transform item = ThisInstance.ItemList.GetChild(i);
            //if the item is not yet active
            if (!item.gameObject.activeSelf)
            {
                item.GetComponent<Image>().sprite = obj.GetComponent<InventoryItem>().icon;// set its sprite to the gui icon of the inventory item
                item.GetComponent<Image>().type = Image.Type.Simple;// set the image type to simple since sliced is default and messes up not displaying the icon as it should
                item.gameObject.SetActive(true);// enabele the itemlist object to be displayed in the inventory panel.
                return;
            }
        }
    }
}
