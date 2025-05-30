using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTrigger (string animationTrigger)
    {
        animator.SetTrigger (animationTrigger);
    }

    public void ChangeCharacterState (CharacterState state)
    {
        animator.SetInteger("StateIndex", (int)state);
    }
    public bool IsAnimationFinished(CharacterState state)
    {
        var info = animator.GetCurrentAnimatorStateInfo(0);
        int wantedHash = Animator.StringToHash(state.ToString());
        if (info.shortNameHash != wantedHash)
            return false;
        return info.normalizedTime >= 1f && !animator.IsInTransition(0);
    }

    public Animator GetAnimator()
    {
        return animator;
    }
    public float GetClipDuration(string clipName)
    {
        var clips = animator.runtimeAnimatorController.animationClips;
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
                return clip.length;
        }
        return 0f;
    }

}
