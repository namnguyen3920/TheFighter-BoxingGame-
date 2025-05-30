using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterKnockOutState : CharacterBaseState
{
    public override void EnterState(CharController character)
    {
        Debug.Log("Character Enter Knockout State");
        character.anim_controller.ChangeCharacterState(CharacterState.Knockout);
        character.anim_controller.SetTrigger("KnockedOut");
    }
    public override void UpdateState(CharController character)
    {
        
    }

    public override void ExitState(CharController character)
    {

    }
}
