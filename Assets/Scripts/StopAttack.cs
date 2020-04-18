using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttack : StateMachineBehaviour
{
    private float timePassed = 0;

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    // 
    // Unity's comment above sounds a bit confusing ... but
    // simply consider this the Update method of StateMachineBehaviours ;)
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        // Debug.Log(timePassed);

        // while timePassed is smaller than the sanimation clip's length
        // do nothing

        // reset the bool
        // 
        // animator.enabled = false;
        if (animator.GetBool("isAttacking") == true)
        {
            timePassed += Time.deltaTime;
            if (timePassed < stateInfo.length) return;

            animator.SetBool("isAttacking", false);
        }
        else
        {
            timePassed = 0;
        }

    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     timePassed = 0;
    // }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
