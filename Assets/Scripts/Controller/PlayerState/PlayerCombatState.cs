using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCombatState : PlayerBaseState
{
    private readonly PunchType punchType;
    [SerializeField] private bool punching = false;
    public PlayerCombatState (PunchType type)
    {
        punchType = type;
    }

    public override void EnterState(PlayerController player)
    {
        Debug.Log("Enter Combat");
        punching = true;
        player.anim_controller.SetTrigger(punchType.ToString());
        player.anim_controller.ChangeCharacterState(CharacterState.Combat);
    }

    public override void OnCollisionEnter(PlayerController player)
    {
        
    }

    public override void UpdateState(PlayerController player)
    {
        if(!punching) { return; }

        if (!punching && player.anim_controller.IsAnimationFinished())
        {
            player.ChangeState(new PlayerIdleState());
        }
    }

    public override void ExitState(PlayerController player)
    {

    }
}
