using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// About this script
/// Whenever the skiig statemachine is activated this script are using player input(also used to control movement) to adjust whcih 
/// animations are playing. which means that when our character(gustav Vasa are skiing downhills at higher speeds)
/// </summary>
public class SkiingAnimationsStateMachine : StateMachineBehaviour
{
    //float used to smoth the transitions betwee
    private float smothTransition = 0.15f;// variable used to smoth out the transitions between the animations in the blend three.
    // this may be useful when using a keyboard to maneuver vasa as blends is not that harch anymore.

    // hashvalues used to identify the two float parameters that drives the blending these are gotten through the animator component.
    private readonly int hashHorisontal = Animator.StringToHash("HorizontalInput");
    private readonly int hashVertical = Animator.StringToHash("VerticalInput");
    /// <summary>
    /// Overriden function for updating the animationstates in the blend three it defines two input parameters and 
    /// uses them to play back the correct blend between the animations
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //get input for horizontal and vertical movement(steers animations not movement. movement are handled in script named moveVasa)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Vector2 compiled by the two input floats
        Vector2 vasaInput = new Vector2(horizontal, vertical).normalized;
        // Set the vertical and horizontal input floats in the animator through the help 
        animator.SetFloat(hashHorisontal, vasaInput.x, smothTransition, Time.deltaTime);
        animator.SetFloat(hashVertical, vasaInput.y, smothTransition, Time.deltaTime);
    }
}
