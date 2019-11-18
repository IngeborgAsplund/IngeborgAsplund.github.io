using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script handles the MainMenue of the game and the major tasks of this element such as starting off new games loading old games, exiting
/// the application and viewing the credits for the game
/// </summary>
public class MainMenue : MonoBehaviour
{
    [SerializeField]
    GameObject[] menueItem;
    RespawnManager spwn;
    RepawnInsans oldsave;
    
    public void Start()
    {
        spwn = GameManager.managerWasa.RespawnManage;
        GameManager.managerWasa.SetGameStateToMenue();
        GameManager.managerWasa.Audio.StartPlayingNewTrack("MainMenue");
        if(GameManager.managerWasa.GameFinished)
        {
            CreditsDisplay();
        }
    }
    /// <summary>
    /// Loads the beginning of a new game
    /// </summary>
    public void StartNewGame()
    {

        //GameManager.managerWasa.LoadScene("3D Player Charecter");
        StartCoroutine(GameManager.managerWasa.Audio.FadeOut());
        //GameManager.managerWasa.LoadScene("3D Player Charecter"); uses for debug
        GameManager.managerWasa.LoadScene("Introduction");//or whatever that is going to be level1    
        GameManager.managerWasa.Audio.StartPlayingNewTrack("Introduction");
        GameManager.managerWasa.UnPausGame();
        GameManager.managerWasa.UnloadScene("MainMenue");
        GameManager.managerWasa.UiHandle.PlayIntroductionStory();
    } 
   
    /// <summary>
    /// Loads an old save using the Static save and loadscripts function for loading an old savefile
    /// </summary>
    public void LoadOldGame()
    {
         oldsave = SaveAndLoad.LoadGameData();
       
        foreach(string s in oldsave.LoadedLevel)
        {
            GameManager.managerWasa.LoadScene(s);
            GameManager.managerWasa.Audio.StartPlayingNewTrack(s);
        }
        
        StartCoroutine(loadDelay());             
    }
    IEnumerator loadDelay()
    {
        yield return new WaitForSecondsRealtime(1);
        GameManager.managerWasa.UnPausGame();
        spwn.RespwnNow(oldsave);
        GameManager.managerWasa.UnloadScene("MainMenue");
        

    }
    /// <summary>
    /// Shuts of the elements that are unnessesary to show when viewing credits and turn on the objects needed to display this
    /// </summary>
    public void CreditsDisplay()
    {
        for (int i = 0; i <= 3; i++)
        {
            menueItem[i].SetActive(false);
        }
        for(int i = 4; i <menueItem.Length;i++)
        {
            menueItem[i].SetActive(true);
        }
        Animator ani = menueItem[5].GetComponent<Animator>();
        ani.Play("Scroll credits",0);
    }
    /// <summary>
    /// Exit the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
    public void GoBackToMenue()
    {
        for (int i = 0; i <= 3; i++)
        {
            menueItem[i].SetActive(true);
        }
        for (int i = 4; i < menueItem.Length; i++)
        {
            menueItem[i].SetActive(false);
        }
        if (GameManager.managerWasa.GameFinished)
            GameManager.managerWasa.GameFinished = false;
    }
}
