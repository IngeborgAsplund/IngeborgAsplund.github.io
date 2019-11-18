using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// StateMachine used by all of the enemies in teh game to get the correct blend between their tilt and their 
/// </summary>
public class DanishSoldierAnimationStateMachine : StateMachineBehaviour
{
    //public smothing value
    private float smothTransition = 0.15f;
    //Readonly hashvalues representing the values of the two blendtree floats used to blend animations 
    private readonly int hashHorizontal = Animator.StringToHash("Tilt");
    private readonly int hashVertical = Animator.StringToHash("Speed");
    private float speed;
    private float tilt;
   /// <summary>
   /// public property for tilt value this is set through a method in the animationmanager valled by soldierbehaviour
   /// </summary>
    public float Tilt
    {
        set { tilt = value; }
    }
    public float Speed
    {
        set { speed = value; }
    }
    /// <summary>
    /// Overriden function for stateupdate used by enemyanimators.
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 daneInput = new Vector2(tilt, speed).normalized;
        animator.SetFloat(hashHorizontal, daneInput.x, smothTransition, Time.deltaTime);
        animator.SetFloat(hashVertical, daneInput.y, smothTransition, Time.deltaTime);
    }


}
