using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController player)
    {
        Debug.Log("Entered IDLE");
        player.anim_controller.ChangeCharacterState(CharacterState.Idle);
    }
    public override void OnCollisionEnter(PlayerController player)
    {
        
    }

    public override void UpdateState(PlayerController player)
    {
        
    }

    public override void ExitState(PlayerController player)
    {

    }
}
