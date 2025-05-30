using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBeingHitState : CharacterBaseState
{
    private bool hit = false;
    public override void EnterState(CharController character)
    {
        hit = true;
        character.anim_controller.ChangeCharacterState(CharacterState.Hit);
        BodyHitAnimations bodyAnimation = (BodyHitAnimations)UnityEngine.Random.Range(0, Enum.GetValues(typeof(BodyHitAnimations)).Length);
        character.anim_controller.SetTrigger(bodyAnimation.ToString());
    }
    public override void UpdateState(CharController character)
    {
        if (hit)
        {
            hit = false;
            character.CharacterChangeState(character.characterIdleState);
        }
    }
    public override void ExitState(CharController character)
    {
        
    }
}
