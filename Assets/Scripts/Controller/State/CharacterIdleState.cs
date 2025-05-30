using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(CharController character)
    {
        character._hitReceiver.gameObject.SetActive(true);
        character.anim_controller.ChangeCharacterState(CharacterState.Idle);
    }
    public override void UpdateState(CharController character)
    {
        
    }

    public override void ExitState(CharController character)
    {

    }
}
