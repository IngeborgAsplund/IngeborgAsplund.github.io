using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Handles different ui elements attached to the canvas object such as arrows for warning players of incomming arrows.
/// </summary>
public class UIHandler : MonoBehaviour {
    [SerializeField]
    private List<GameObject> UiElemements;
    [SerializeField]
    private List<Sprite> Uisprites;
    [SerializeField]
    private GameObject lookAtSoldiers;
    [SerializeField]
    private RespawnManager spawner;// this needs a reference to the respawnmanager
    private bool pausMenueActive;//check if pausmenue is active
    private bool tutorialActive;// is the tutorial currently active in that case do the stuff tutorial1 and 2 says.
    private bool tutorialRun;// if tutorial already have been run this is true and the tutorial wont retrigger
    private bool spacePressed;// check if scace have been pressed then it will check for the other tutorial functions and update accordingly
    private bool gameIsOver;// bool that only comes true at the very end of the game determining if the game should go out to main menue or not when the player presses continue
   
    //list variable gotten from gamemanager
    List<GameObject> localDanes;// list that contains the danish soldiers in the scene for better and more convenient sorting of list
    
    public bool GameIsOver
    {
        set { gameIsOver = value; }
    }
    private void Start()
    {
        GameManager.managerWasa.IAmaUIHandler(this);
        StartCoroutine(FindRotationReference(0.1f));
        localDanes = new List<GameObject>();//initializes list 
        UpdateListOfDanish();
        pausMenueActive = false;        
    }
  
    private void Update()
    {
        if (GameManager.managerWasa.Enemys.Count > 0)
            ClosestDane();
        else
            UiElemements[0].SetActive(false);
        PausMenue();
        CheckInput();

    }
    /// <summary>
    /// This updates the list of dahishmen dynamically whenever a danish soldier get spawned making the list to renew each time a danish respawn or despawn
    /// </summary>
    public void UpdateListOfDanish()
    {
        if (localDanes != null && GameManager.managerWasa.Enemys.Count > 0)
        {
            localDanes.Clear();
            foreach (GameObject da in GameManager.managerWasa.Enemys)// add all of the sodliers found in gamemanager to the list of local danes
            {
                localDanes.Add(da);
                Debug.Log("Dane");
            }
        }
        
    }
   
    /// <summary>
    /// function that display the ui arrow
    /// </summary>
    private void DisplayArrow(GameObject dane)
    {
        if (!UiElemements[0].active)
            UiElemements[0].SetActive(true);
        if (lookAtSoldiers != null)
        {
            lookAtSoldiers.transform.LookAt(dane.transform);
            //Debug.Log(lookAtSoldiers.transform.rotation.x.ToString());
            Vector3 myrot = lookAtSoldiers.transform.rotation.eulerAngles;
            UiElemements[0].transform.rotation = Quaternion.Euler(0, -180, myrot.y - GameManager.managerWasa.Player.transform.rotation.eulerAngles.y + 90);
        }
        else
            StartCoroutine(FindRotationReference(0.1f));


    }
    
    /// <summary>
    /// This method is designed to find the closest danish soldier in the list of local danes and then send him into the pointer funtion
    /// and then call the other methods that have to do with the arrow function
    /// </summary>
    private void ClosestDane()
    {
        
        for(int i = 0;i < localDanes.Count; i++)
        {            
            SoldierBehaviour soldier = localDanes[i].GetComponent<SoldierBehaviour>();
            soldier.MyDistance = localDanes[i].transform.position - GameManager.managerWasa.Player.transform.position;
        }
        localDanes = localDanes.OrderBy(x => x.GetComponent<SoldierBehaviour>().MyDistance.z).ToList();
        GameObject closestDane = localDanes[0];
        // function that controls the visibility of the arrow icon shut down for 
        float distancetoWasa = closestDane.transform.position.z - GameManager.managerWasa.Player.transform.position.z;
        if (distancetoWasa > -6 && distancetoWasa < 15)
        {
            DisplayArrow(closestDane);
            FillArrow(closestDane);
        }
        else
        {
            EraseArrow(closestDane, 0f);
            UiElemements[0].SetActive(false);
        }

    }
    /// <summary>
    /// Changes the danger arrow sprite so that it get full saturation. 
    /// </summary>
    private void FillArrow(GameObject danishman)
    {
        if (danishman.GetComponent<SoldierBehaviour>().HaveShoot)
        {
            UiElemements[0].GetComponent<Image>().sprite = Uisprites[1];
            danishman.GetComponent<SoldierBehaviour>().HaveShoot = false;
            StartCoroutine(EraseArrow(danishman, 6f));
        }
        //for(int i = 0; i < GameManager.managerWasa.danishSoldiers.Length;i++)
        //{
        //    if(GameManager.managerWasa.danishSoldiers[i].GetComponent<SoldierBehaviour>().state == SoldierBehaviour.State.ATTACK)
        //    {
        //          UiElemements[0].sprite = Uisprites[1];   
        //    }

        //}
    }
    /// <summary>
    /// Remove the arrow from the ui making it transparent again.
    /// </summary>
    private IEnumerator EraseArrow(GameObject secoundDane, float wait)
    {
        yield return new WaitForSeconds(wait);
        if (!secoundDane.GetComponent<SoldierBehaviour>().HaveShoot)
        {
            UiElemements[0].GetComponent<Image>().sprite = Uisprites[0];
            
        }
        //for (int i = 0; i < GameManager.managerWasa.danishSoldiers.Length; i++)
        //{
        //    if (GameManager.managerWasa.danishSoldiers[i].GetComponent<SoldierBehaviour>().HaveShoot == true) 
        //    {
        //        UiElemements[0].sprite = Uisprites[0];
        //        GameManager.managerWasa.danishSoldiers[i].GetComponent<SoldierBehaviour>().HaveShoot = false;
        //        Debug.Log("Red");
        //    }

        //}
    }
    /// <summary>
    /// Call this when the player has died it makes the interface go black and writes a fun snappy text over the screen
    /// </summary>
    public void PlayerDead()
    {
        GameManager.managerWasa.PausGame();
        Text dead = UiElemements[2].GetComponent<Text>();
        UiElemements[1].SetActive(true);
        dead.text = "That was not what happened";
        UiElemements[2].SetActive(true);
        StartCoroutine(Alive(2, dead));
       
    }
    /// <summary>
    /// Method that calls a pausmenue containing the options to reload latest save(spawnpoint, this can be needed should the player get stuck
    /// or end up in a situation where danish soldiers are cornering wasa making it hard to get away) Resume game, Go to main menue
    /// and Quit(quit means the game returns to the latest saved spawnpoint when reloaded from the main menue).
    /// </summary>
    public void PausMenue()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!GameManager.managerWasa.IsGameInMenue())
        {
            if (!pausMenueActive)
            {
                GameManager.managerWasa.PausGame();
                for (int i = 3; i <= 6; i++)
                {
                    UiElemements[i].SetActive(true);
                }
                pausMenueActive = true;
            }
            
        }        

    }
    /// <summary>
    /// Unpauses the game and resumes gameplay
    /// </summary>
    public void Resume()
    {       
        for (int i =3;i <= 6; i++)
        {
            UiElemements[i].SetActive(false);
        }
        GameManager.managerWasa.UnPausGame();
        pausMenueActive = false;
    }
    /// <summary>
    /// This deserializses and loads the latest save making it possible to jump back to a previous spawnpoint or continue an already started game
    /// when pressing the load button. This needs testing
    /// </summary>
    public void LoadSave()
    {
        spawner = GameManager.managerWasa.RespawnManage;// current solution will be replaced when respawnsystem is rewamped to higher level in hierarchy
        RepawnInsans inst = SaveAndLoad.LoadGameData();// create respawninstance that is used for loading the game       
        spawner.RespwnNow(inst);// calls the respawn now function of the respawnmanager
        Resume();// resumes game to where it was for a little while ago.    
    }
    /// <summary>
    /// This switches the scene to a main menuescreen after saving the data of the current games data
    /// </summary>
    public void BackToMainMenue()
    {
        spawner = GameManager.managerWasa.RespawnManage;
        spawner.SaveCurrentGameData();
        foreach(GameObject g in UiElemements)
        {
            g.SetActive(false);
        }
        List<string> loadedscenes = GameManager.managerWasa.Levels();
        //unload all scenes except game manager
        foreach(string s in loadedscenes)
        {           
                GameManager.managerWasa.UnloadScene(s);
        }
        GameManager.managerWasa.Awake();// runs awake method for gamemanager again
        //load the mainmenuescene
        GameManager.managerWasa.LoadScene("MainMenue");
        GameManager.managerWasa.Audio.StartPlayingNewTrack("MainMenue");
    }
    /// <summary>
    /// Same as the above but instead we quit the application after saving all the required data.
    /// </summary>
    public void ExitAllpication()
    {
        spawner = GameManager.managerWasa.RespawnManage;
        spawner.SaveCurrentGameData();
        Application.Quit();
    }
    /// <summary>
    /// This function displays the beginning of the story when starting a new game  and is used to give context to the games narrative
    /// </summary>
    public void PlayIntroductionStory()
    {
        GameManager.managerWasa.PausGame();
        UiElemements[7].SetActive(true);
        UiElemements[8].SetActive(true);
       
    }

    /// <summary>
    /// Display the tutorial for how to move and put on skiis.
    /// </summary>
    public void TutorialOne()
    {
        if (!tutorialRun)
        {
            UiElemements[10].SetActive(true);
            UiElemements[2].GetComponent<Text>().text = "Tutorial starts";
            UiElemements[2].SetActive(true);
            tutorialActive = true;
        }
        
    }  
    private void CheckInput()
    {
       if(tutorialActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UiElemements[10].SetActive(false);
                UiElemements[9].SetActive(true);
                UiElemements[2].SetActive(false);
                spacePressed = true;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
            {
                if (spacePressed)
                {
                    UiElemements[9].SetActive(false);
                    tutorialActive = false;
                    tutorialRun = true;
                }          
            }
            
        }
    }
    /// <summary>
    /// Diplay tutorial about enemies and the idea of running from them. This is triggered by the tutorialshowcase script
    /// </summary>
    public void TutorialTwo()
    {
        UiElemements[11].SetActive(true);
        StartCoroutine(EndTutorialTwo(5));
    }
    
   
    /// <summary>
    /// Ienumerator for ending the secound tutorial as well as removes text at the end of the level.
    /// </summary>
    /// <param name="secound"></param>
    /// <returns></returns>
    private IEnumerator EndTutorialTwo(float secound)
    {
        yield return new WaitForSecondsRealtime(secound);
        UiElemements[11].SetActive(false);
        UiElemements[2].SetActive(false);
    }
    /// <summary>
    /// This function is used to frame the narrative of specific event such as staying the night in a village or arriving to a new place giving us a snippet of lore from the life of Gustav Vasa
    /// </summary>
    /// <param name="message"></param>
    public void TellStory(string message, bool blackScreen)
    {
        if (blackScreen)
        {
            UiElemements[1].SetActive(true);
        }
        Text story = UiElemements[7].GetComponentInChildren<Text>();
        story.text = message;
        UiElemements[7].SetActive(true);
        UiElemements[8].SetActive(true);
        GameManager.managerWasa.PausGame();
    }
    /// <summary>
    /// This returns the games state to normal and is called through corutine that is active for a set amount of time
    /// </summary>
    public void StoryEnds(bool blackscreen)
    {
        if (blackscreen)
            UiElemements[1].SetActive(false);
        UiElemements[7].SetActive(false);
        UiElemements[8].SetActive(false);
        GameManager.managerWasa.Audio.ResetSound();
        if (gameIsOver)
        {
            GameManager.managerWasa.GameFinished = true;
            GameManager.managerWasa.LoadScene("MainMenue");
            GameManager.managerWasa.UnloadScene("Castle In Stockholm");
        }                 
        GameManager.managerWasa.UnPausGame();
    }
    /// <summary>
    /// Function that resets the interface for when the player is resurected/ is respawned
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="txt"></param>
    /// <returns></returns>
    private IEnumerator Alive(float interval, Text txt)
    {
        yield return new WaitForSecondsRealtime(interval);
        txt.text = string.Empty;
        UiElemements[1].SetActive(false);
        UiElemements[2].SetActive(false);
        GameManager.managerWasa.UnPausGame();
    }   
    /// <summary>
    /// Function that helps with finding the reference for the look at danes object
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator FindRotationReference(float time)
    {
        yield return new WaitForSeconds(time);
        lookAtSoldiers = GameManager.managerWasa.UIRotationRefrence;
    }
   
  }
