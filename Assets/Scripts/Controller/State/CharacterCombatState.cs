using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterCombatState : CharacterBaseState
{
    private readonly PunchType punchType;
    [SerializeField] private bool punching = false;

    public override void EnterState(CharController character)
    {
        Debug.Log("Character Enter Combat State");
        punching = true;
        character.anim_controller.SetTrigger(punchType.ToString());
        character.anim_controller.ChangeCharacterState(CharacterState.Combat);
    }

    public override void UpdateState(CharController character)
    {
        if (punching)
        {
            punching = false;
            character.CharacterChangeState(character.characterIdleState);
        }
        else return;
    }

    public override void ExitState(CharController character) 
    {
        punching = false;
    }
}
