using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToIdleState : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo info, int layer)
    {
        animator.SetInteger("StateIndex", 0);
    }
}
