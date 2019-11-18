[SerializeField]
    private GameObject[] skiNesseseties;
    // ski animations.
    /// <summary>
    /// Awake function that finds the player character
    /// </summary>
    public void Start()
    {
        player = GameManager.managerWasa.Player;
        rigid = player.GetComponent<Rigidbody>();
        movement = player.GetComponent<MoveVasa>();
        playerAnim = player.GetComponentInChildren<Animator>();
        GameManager.managerWasa.IAmAnAnimationManager(this);
        skiingactive = false;
        hasTransisted = false;
        runOnce = false;
        oldRota = player.transform.rotation;//save players rotation in the beginning of the game
        Debug.Log(playerAnim.isHuman + " animatot");
    }
    public void Update()
    {
        speed = rigid.velocity.magnitude;
        if (skiingactive)
        {
            SkiiChangeAfterInput();
        }             
    }
    /// <summary>
    /// property for bool that enables the coroutine enabling and disabling gustavs skiis and staff ensuring that it is only called once
    /// </summary>
    public bool MySwitch
    {
        get { return runOnce; }
        set { runOnce = value; }
    }
    /// <summary>
    /// property for a boolean determining if vasa wears skiis 
    /// </summary>
    public bool SkiingModelActive
    {
        set { skiingactive = value; }
    }
    //PlayerAnimations
    /// <summary>
    /// sets the bools for starting the walkanimation in the player character
    /// </summary>
	public void StartWalkanimation()
    {
        //if (skiingactive)
        //{
        //    for (int i = 0; i < skiNesseseties.Length; i++)
        //    {
        //        skiNesseseties[i].SetActive(false);
        //    }
        //    //gustavSkiing.enabled = false;
        //    playerAnim.enabled = true;
        //    //playerAnim.SetBool("Walks", true);
        //    skiingactive = false;

        //}    
        hasTransisted = true;        
        playerAnim.SetBool("Walks", true);
        playerAnim.SetBool("Skiis", false);
        playerAnim.SetBool("Planar", true);
        if (!runOnce)
        {
            StartCoroutine(WaitbeforeChange(0.5f));
            runOnce = true;
        }
          


    }
    /// <summary>
    /// Starts the animations for skiing enabling and disabling different animations depending on the tilt of the 
    /// player character.
    /// </summary>
    public void SkiingAnimation()
    {
        hasTransisted = false;
        //shut down the skiing 
        if (!runOnce)
        {
            StartCoroutine(WaitbeforeChange(0.5f));
            runOnce = true;
        }
         
        playerAnim.SetBool("Walks", false);
        //activate our staff and skiis
        //for (int i = 0; i < skiNesseseties.Length; i++)
        //{
        //    skiNesseseties[i].SetActive(true);
        //}
        //start skiing animation three
        playerAnim.SetBool("Skiis", true);               
        skiingactive = true;
        //playerAnim.enabled = false;
        //gustavSkiing.enabled = true;


    }
    /// <summary>
    /// This method is called by update and only if the skiingmodelactive bool is true, it checks if the players tilt exeeds
    /// a specific degree or if gustav goes in a left or right direction and plays different animation tilt in y direction and
    /// as well as x direction
    /// </summary>
    private void SkiiChangeAfterInput()
    {
        //bool tilts = TiltDown(oldRota, player.transform.rotation);        
        //bool right = TurnRight(oldRota, player.transform.rotation); 
        if (speed > 8&&movement.IsGrounded)// if we are faster than 8
        {
            //gustavSkiing.SetBool("Downhill", true);
            playerAnim.SetBool("Planar",false);
            playerAnim.SetBool("Floating", false);
            //works
        }
        else if(speed<=8&&movement.IsGrounded)
        {
            playerAnim.SetBool("Planar", true);
           //gustavSkiing.SetBool("Downhill", false);
            playerAnim.SetBool("Floating", false);
            //works            
        }
        if (!movement.IsGrounded)
        {
            //Move at planar skiing speed
            playerAnim.SetBool("Floating",true);
            //works
        }
    }
    /// <summary>
    /// Ienumerator for switching to and from wearing skiis this will be called by the idle carousel the start walk and the start skiing
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitbeforeChange(float waitTime)
    {        
        yield return new WaitForSeconds(waitTime);
        if (!hasTransisted)// we are transisting from walk or idle in this case
        {
            for (int i = 0; i < skiNesseseties.Length; i++)
            {
                skiNesseseties[i].SetActive(true);
            }
        }
        else // now we are gooing over from skiing to walking or idling
        {
            if (skiingactive)
            {
                for (int i = 0; i < skiNesseseties.Length; i++)
                {
                    skiNesseseties[i].SetActive(false);
                }
                //gustavSkiing.enabled = false;
                //playerAnim.enabled = true;
                //playerAnim.SetBool("Walks", true);
                skiingactive = false;                
            }
        }
    }

    /// <summary>
    /// shooting animation trigger stops any other animation and plays the one for shooting at gustav once the attack state is activated
    /// it calls for the enemies native animator as well as the 
    /// </summary>
    /// <param name="danimator"></param>
   public void DaneTriggerShooting(Animator danimator)
    {       
            danimator.SetBool("Shoot", true);     
    }
   public void SetAnimatorValues(Animator danimator, SoldierBehaviour s, GameObject d)
    {
        DanishSoldierAnimationStateMachine m = danimator.GetBehaviour<DanishSoldierAnimationStateMachine>();
        float speed = d.GetComponent<Rigidbody>().velocity.magnitude;
        float tilt = TiltValue(s.originalRot,d.transform.rotation);
        m.Speed = speed;
        m.Tilt = tilt;
    }
    /// <summary>
    /// Function that compares the euleranles.Y value of two quarternions, to get the value for the tiltvalue in the animator, public function that the danes 
    /// statemachine can call and use
    /// </summary>
    /// <returns></returns>
    public float TiltValue(Quaternion from, Quaternion towards)
    {
        float fromY = from.eulerAngles.y;
        float toY = towards.eulerAngles.y;
        float tilt = 0f;
        tilt = fromY - toY;
        //if (fromY <= toY)
        //{
        //    tilt = toY - fromY;

        //}
        //else
        //{
        //    tilt = (360 - fromY) + toY;

        //}
        return tilt;

    }
    /// <summary>
    /// This function reset the animations to the slow skiing pattern that is used when the dane is neither shooting arrows nor returned back to its chase state yet
    /// </summary>
    /// <param name="danimator"></param>
    public void BackToBasic(Animator danimator)
    {
        danimator.SetBool("Shoot", false);     
    }
    /// <summary>
    /// Check if the players velocity.Magnitude is lower than what it was when starting going downhills this triggers the animation
    /// for useage of staffs to get forward and if velocity.magnitude is lower than [specified value] the animations swich down to
    /// the planar skiing animation otherwise it goes back to the skiing downhill animation
    /// </summary>
    //private void VelocityChangeLow()
    //{      
    //   // if we goes so slow it is motivated put the stop haste animation to false too and start planar
    //   if (rigid.velocity.magnitude < 8)
    //     {
    //        gustavSkiing.SetBool("Stop haste", false);
    //        gustavSkiing.SetBool("Planar", true);
    //        //Debug.Log("Planar");
    //     }
    //   // if the velocity goes up again the speed will increase once again
    //   if (rigid.velocity.magnitude >10)
    //     {
    //       gustavSkiing.SetBool("DownHill", true);
    //       gustavSkiing.SetBool("Stop haste", false);
    //       gustavSkiing.SetBool("Planar", false);
    //       //Debug.Log("speed up");
    //     }      
    //}

    /// <summary>
    /// Bool that checks if we are tilting downwards comparing the old rotation with the current one.
    /// It takes two quarternions as parameters and returns true if we are tilting down false if we are tilting up
    /// </summary>
    /// <returns></returns>
    private bool TiltDown(Quaternion from, Quaternion towards)
    {
        float fromX = from.eulerAngles.x;
        float toX = towards.eulerAngles.x;
        float tiltDown = 0f;
        float tiltUp = 0f;
        //if the original axis Y aspect is bigger than the y aspect of tha axis our player are turning towards
        //the below code is executed
        if (fromX <= toX)
        {
            tiltDown = toX - fromX;
            tiltUp = fromX + (360 - toX);
        }
        //else it is will be reversed
        else
        {
            tiltDown = (360 - fromX) + toX;
            tiltDown = fromX - toX;
        }
        // true if tiltdown is equal to or bigger than tiltup
        return (tiltDown <= tiltUp);
    }
   
    /// <summary>
    /// Shifts between a set of idle animations when the player does nothing
    /// </summary>
    public void IdleCarousel()
    {
        hasTransisted = true;
        if (!runOnce)
        {
            StartCoroutine(WaitbeforeChange(1.5f));
            runOnce = true;
        }
            
                 
        //check if gustav vasa is wearing his skiis.
        //if (skiingactive)
        //{
        //    for (int i = 0; i < skiNesseseties.Length; i++)
        //    {
        //        skiNesseseties[i].SetActive(false);
        //    }

        //    //playerAnim.enabled = true;
        //    //gustavSkiing.enabled = false;
        //    skiingactive = false;
        //}
        playerAnim.SetBool("Walks", false);
        playerAnim.SetBool("Skiis", false);
        playerAnim.SetBool("Planar", true);
        //Here a switch state-machine for different idles could be implemented here
    }
}
