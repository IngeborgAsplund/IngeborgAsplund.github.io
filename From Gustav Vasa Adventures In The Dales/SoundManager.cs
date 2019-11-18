using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this class is used to playback certain sounds and tracks of music dependent on scenes and situation
/// </summary>
public class SoundManager : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private List<AudioClip> soundtracks;//List of music that should be looping according to which level are loaded
    [SerializeField]
    private List<AudioClip> sfx;//list of effect clips that may play in the following situations, hit by arrow(3d) danish spawn(3D), interacting npc(2D),interacting door(2D)interacting objects(2D)
    private AudioSource myAudio;
    [SerializeField]
    private AudioSource effects;// this is a secound audiosource used to play back effect sounds
    [SerializeField]
    private float fadeRate;
    private bool audioReset;

    /// <summary>
    /// property for the audioreset bool which will be true when theaudio shall reset
    /// </summary>
    public bool AudioReset
    {
        set { audioReset = value; }
    }
    /// <summary>
    /// property for the faderate variable
    /// </summary>
    public float FadRate
    {
        get { return fadeRate; }
        set { fadeRate = value; }
    }

    void Start()
    {
        GameManager.managerWasa.IAmASoundManager(this);
        myAudio = GetComponent<AudioSource>();
    }
    /// <summary>
    /// Chooses music according to different places in the world using the names of specific scenes to choose which music to play where
    /// <param name="loadedSceneName"></param>
    public void StartPlayingNewTrack(string songName)
    {
        switch (songName)
        {
            case "MainMenue"://menue music
                myAudio.clip = soundtracks[3];
                myAudio.loop = true;
                myAudio.Play();
                break;
            case "Introduction":// introduction              
                myAudio.clip = soundtracks[0];
                myAudio.loop = true;
                StartCoroutine(FadeIn(1));
                break;
            case "3D Player Charecter": //whenever the 3DPlayer character  
                myAudio.clip = soundtracks[4];
                myAudio.loop = true;
                StartCoroutine(FadeIn(1));                
                break;
            case "Baylake Village"://music of baylake village may be used on more places
                Debug.Log("town");
                myAudio.clip = soundtracks[2];
                myAudio.loop = true;
                StartCoroutine(FadeIn(0.3f));
                break;
            case "Huge Farmhouse":
            case "Sigruds House":
                myAudio.clip = soundtracks[1];
                myAudio.loop = true;
                StartCoroutine(FadeIn(0.9f));
                break;
            case "Castle In Stockholm":// music for the castle end sequence
                myAudio.clip = soundtracks[0];
                myAudio.loop = true;
                StartCoroutine(FadeIn(1));
                break;

        }
    }

    /// <summary>
    /// This function plays back a soundeffect depending on the type of object that calls it. or instance everytime a dane spawns he calls this with the phrase"Danish", a dorr that
    /// get opened however sends this method a "Door".
    /// </summary>
    /// <param name="objectName"></param>
    public void PlaySoundEffect(string objectType)
    {
        switch (objectType)
        {
            case "Danish":
                effects.clip = sfx[3];
                effects.loop = false;
                effects.Play();
                break;
            case "Arrow":
                effects.clip = sfx[1];
                effects.loop = false;
                effects.Play();
                break;
            case "DoorOpen":
                effects.clip = sfx[5];
                effects.loop = false;
                effects.Play();
                break;
            case "Letter":
                effects.clip = sfx[4];
                effects.loop = false;
                effects.Play();
                break;
            case "StayOverNight":
                myAudio.clip = sfx[2];
                myAudio.loop = false;
                myAudio.Play();
                break;
            case "NPC":
                effects.clip = sfx[4];
                effects.loop = false;
                effects.Play();
                break;
            case "ThroneInStockholm":
                effects.clip = sfx[0];
                effects.loop = false;
                effects.Play();
                break;
        }
    }
    /// <summary>
    /// Custom made function that reset the sound to what it was in the scene before, this is called specifically when the game has switched sound on the main audio source briefly for special
    /// effekt of some kind for instance when a story sequence plays a sound that when the user press the continue button should go back to normal.
    /// </summary>
    public void ResetSound()
    {
        if (audioReset)
        {
            List<string> loadedNames = GameManager.managerWasa.Levels();
            foreach (string name in loadedNames)
            {
                StartPlayingNewTrack(name);
            }
            audioReset = false;
        }

    }
    /// <summary>
    /// Fades in the new music when switching scene
    /// </summary>
    public IEnumerator FadeIn(float desiredVolume)
    {       
        float volume = myAudio.volume;
        myAudio.Play();
        while (myAudio.volume < desiredVolume)
        {
            myAudio.volume += volume * Time.deltaTime / fadeRate;
            if (myAudio.volume >= desiredVolume)
                break;
        }
        myAudio.volume = desiredVolume;
        yield return null;
        
    }
    /// <summary>
    /// Fades out the old music 
    /// </summary>
    public IEnumerator FadeOut()
    {
        float volume = myAudio.volume;
        while (myAudio.volume >=0.2)
        {
            myAudio.volume -= volume * Time.deltaTime / fadeRate;
            if (myAudio.volume <= 0)
                break;
        }
        yield return null;
    }
    
}
