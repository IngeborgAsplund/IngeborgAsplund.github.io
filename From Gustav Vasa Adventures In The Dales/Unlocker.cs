using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    [SerializeField]
    private SwitchSceneAfterClick lockedobj;//this object is locked 
    [SerializeField]
    private bool interactable; //this bool can be used to disallow actions to be taken on specific objects dependent on certain conditions ie, you interacted with an npc or object  
    DialogueManager manager;
    /// <summary>
    /// Startfunction
    /// </summary>
    private void Start()
    {
        manager = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
    }
    /// <summary>
    /// This is the property for the interactable bool above
    /// </summary>
    public bool Interactable
    {
        set { interactable = value; }
    }
    /// <summary>
    /// Unlock the above item so that it can be used.
    /// </summary>
    public void Unlock()
    {
        if (this.gameObject.name == "Letter")
            GameManager.managerWasa.Audio.PlaySoundEffect("Letter");
        lockedobj.Locked = false;
    }
    /// <summary>
    /// this function makes a small paus showing the black screen usually used for the player dead screen in 3d but with different text applied.
    /// after a short while it returns to normal and unlocks the door it was tied to.
    /// </summary>
    public void StayTheNight()
    {
        if (interactable)
        {
            GameManager.managerWasa.Audio.PlaySoundEffect("StayOverNight");
            string message = "So I ended up helping Bengt and his family out for a few days. I must confess that " +
           "I am not that used to hard labour but I soon learned all about how things is done here. " +
           "The food has been great although simple in comparison with what I am used to. But now my dear readers " +
           "it was time to continue towards the town of Falun. " +
           "Maybee I can have a chance convincing the people there about my greatness and that I should be their king.";
            GameManager.managerWasa.UiHandle.TellStory(message, true);
            lockedobj.Locked = false;
            GameManager.managerWasa.Audio.AudioReset = true;
        }
        else
        {
            manager.CannotInteract("Bengt: Hey what are you doing ? This isn't your home young lad!");
        }
                 
    }
    /// <summary>
    /// This function will trigger once the throne is clicked and play the concluding sequence of the story before the game returns to its main menue
    /// </summary>
    public void Throne()
    {
        if (interactable)
        {
            GameManager.managerWasa.Audio.PlaySoundEffect("ThroneInStockholm");
            string message = "So after a long journey and a fierce battle I, Gustav Eriksson Vasa took back the land and became the new ruler." +
            "Now I just have to see to that any throne pretendants are handled with and then I and my future family will be able to rule" +
            " over Sweden for generations to come. Of course, all of us will be fair rulers only punishing those who deserve it...Which is" +
            " all who do not listen to the king. Because now my words are law.";
            GameManager.managerWasa.UiHandle.TellStory(message, false);
            GameManager.managerWasa.UiHandle.GameIsOver = true;

        }
        
    }

    
    
  

}
