using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetTrigger (string animationTrigger)
    {
        animator.SetTrigger (animationTrigger);
    }

    public void ChangeCharacterState (CharacterState state)
    {
        animator.SetInteger("StateIndex", (int)state);
    }
    public bool IsAnimationFinished()
    {
        var stateIndex = animator.GetCurrentAnimatorStateInfo(0);
        return stateIndex.normalizedTime >= 1f && !animator.IsInTransition(0);
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
