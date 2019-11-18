using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{
    public enum States { PATROL,CHASE,ATTACK};
    private LineSight lineOfSight = null;
    [SerializeField]
    private States currentState = States.PATROL;
    private NavMeshAgent agent = null;// navigation mesh agent 
    private Transform mytransform = null;
    public Health playerHealth = null;
    private Transform playerTransform = null;
    [SerializeField]
    private Transform destinationPoint = null;// assign this in the inspector, it is generally better to use a serialized field than a public variable
    [SerializeField]
    private float damage = 10f;
   
    /// <summary>
    /// Public property for the currentstate we are in it is also responsible for determining which coroutine should be started next via a switch 
    /// statement fucntion inside the set functionality
    /// </summary>
    public States CurrentState
    {
        get { return currentState; }
        set
        {
            currentState = value;
            StopAllCoroutines();
            switch (currentState)
            {
                case States.PATROL:
                    StartCoroutine(AIPatroll());
                    return;
                case States.CHASE:
                    StartCoroutine(AIChase());
                    return;
                case States.ATTACK:
                    StartCoroutine(AIAttack());
                    return;
            }
        }
    }

    /// <summary>
    /// Basic skeleton for each of the different states as we want to code them as separate corourines so that two or more of these can be called
    /// simmulaneously without stacking up in qeue. Below is the Ienumerator for what to do when we are patrolling
    /// </summary>
    /// <returns></returns>
    public IEnumerator AIPatroll()
    {
        while (currentState == States.PATROL)
        {
            //set line of sight sensitivity mode to strict
            lineOfSight.senitiviity = LineSight.Sensitivity.Strict;
            //makes the ai agent go back to patrolling
            agent.isStopped = false;// resume patroling in case we are commanded to stop
            agent.SetDestination(destinationPoint.position);// set the destination to patrol towards to the destination of the the waypoints current position.

            while (agent.pathPending)//wait until the agent calculated its path before proceeding further to check for the player.
                yield return null;
            //If we can see the player we set our state to chase and break the loop
            if (lineOfSight.canSeeTarget)
            {
                agent.isStopped = true; ;//agent stops in place;
                CurrentState = States.CHASE;

                yield break;
            }
            // wait until the next frame
            yield return null;
        }
        
    }
    /// <summary>
    /// Coroutine for chasing the player
    /// </summary>
    /// <returns></returns>
    public IEnumerator AIChase()
    {
        while(currentState == States.CHASE)
        {
            //the first thing we want to do is setting the sensitivity to loose as the enemy should be more aware of his surroundings when actively chasing the player
            lineOfSight.senitiviity = LineSight.Sensitivity.Loose;

            agent.isStopped = false; // restart the movement function of the agent since it will 
            agent.SetDestination(lineOfSight.lastSpottedPosition);// we send the ai towards the position where it last spotted the player theis variable could be woth acessing with property.
            // wait while calculating our path
            while (agent.pathPending)
                yield return null;
            //if we are at the destination or has passed it change behaviour to attack. 
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.isStopped = true;
                //check if we can still see the target if not go back to patrolling else attack/fire.In case of enemies with ranged weapons, guns, harpoons etc it should be fitting
                // to have a range variable to compare with the destination and or the positon of the player in order to stop earlier and fire
                if (!lineOfSight.canSeeTarget)
                {
                    CurrentState = States.PATROL;
                }
                else
                {
                    CurrentState = States.ATTACK;
                }
                yield break;
            }

            yield return null;
        }
        
    }
    /// <summary>
    /// coroutine for attacking the player.
    /// </summary>
    /// <returns></returns>
    public IEnumerator AIAttack()
    {
        while(currentState == States.ATTACK)
        {
            agent.isStopped = false;
            agent.SetDestination(playerTransform.position);

            while (agent.pathPending)
                yield return null;
            //check if the player has run away if he has we shoul stop the agent and return to chasing
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                CurrentState = States.CHASE;
                yield break;
            }
            //as long as the player is within reach we want to deal damage to him/her over time in a more complex phase here would be where we shoot projectiles,
            // or use weapon combos to determine the amount of damage to deal.
            else
                playerHealth.HealthPoints -= damage * Time.deltaTime;
            

            yield return null;
        }
        
    }
    /// <summary>
    /// In awake all of the needed variables are assigned to their respective values
    /// </summary>
    void Awake()
    {
        lineOfSight = GetComponent<LineSight>();
        agent = GetComponent<NavMeshAgent>();// get the reference to the navmesh agent used to move around in the scene
        mytransform = GetComponent<Transform>();
        playerTransform = playerHealth.gameObject.GetComponent<Transform>();
    }
    //in start we set the state to patrol
    private void Start()
    {
        CurrentState = States.PATROL;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
  
}
