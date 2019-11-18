using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class 
/// </summary>
public class TutorialShowcase : MonoBehaviour
{
    //the number for which tutorial shall be displayed via the uihandler
    [SerializeField]
    private int tutorialNumber;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (tutorialNumber)
            {
                case 0:
                    GameManager.managerWasa.UiHandle.TutorialOne();
                    break;
                case 1:
                    GameManager.managerWasa.UiHandle.TutorialTwo();
                    break;              
            }
        }
    }
   

}
