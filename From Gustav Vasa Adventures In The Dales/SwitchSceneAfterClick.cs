using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneAfterClick : MonoBehaviour
{
    [SerializeField]
    private string[] scenesToLoad;
    [SerializeField]
    private string[] scenesToUnload;
    [SerializeField]
    private DialogueManager manager;
    [SerializeField]
    private bool locked;
    [SerializeField]
    private string message;
    [SerializeField]
    string leaveScene;// write out this as a message before leaving the scene
    /// <summary>
    /// property for the locked bool
    /// </summary>
    public bool Locked
    {
        set { locked = value; }
    }  
    /// <summary>
    /// main function to load and unload scenes from 2d, this can be used to load interior environments or continue onto the skiing mountains
    /// </summary>
    public void SwitchScene()
    {
        if (!locked)
        {
            GameManager.managerWasa.Audio.FadRate = 1;
            StartCoroutine(GameManager.managerWasa.Audio.FadeOut());           
            GameManager.managerWasa.Audio.PlaySoundEffect("OpenDoor");           
            manager.SceneSwitchMessage(leaveScene);           
            StartCoroutine(LoadWait(1.4f));            
            
        }
        else
        {
            manager.CannotInteract(message);
        }
    }
    /// <summary>
    /// short loadtime wait after you open a door
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private IEnumerator LoadWait( float s)
    {
        yield return new WaitForSecondsRealtime(s);
        LoadScenes();
        UnloadScenes();
    }
    /// <summary>
    /// Loads the scenes listed in the scenes to load array. This is similar to the scenetrigger used for 3D but is triggered when clicking instead of colliding
    /// </summary>
    private void LoadScenes()
    {
        foreach(var name in scenesToLoad)
        {
            if (name != "")
            {
                GameManager.managerWasa.LoadScene(name);
                GameManager.managerWasa.Audio.StartPlayingNewTrack(name);
            }
        }
    }
    /// <summary>
    /// Similar to the above one but unloads scenes
    /// </summary>
    private void UnloadScenes()
    {
        foreach(var name in scenesToUnload)
        {
            if (name != "")
            {
                if (name != "")
                {
                    GameManager.managerWasa.UnloadScene(name);
                    
                }
            }
        }
    }
}
