using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttack : StateMachineBehaviour
{
    private float timePassed = 0;

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
}
