using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public AnimationController anim_controller;
    public PlayerInputMN p_action;

    [SerializeField] PlayerBaseState currentState;
    PlayerIdleState idleState = new PlayerIdleState();
    PlayerBeingHitState beingHitState = new PlayerBeingHitState();
    PlayerKnockOutState knockOutState = new PlayerKnockOutState();
    private void OnEnable()
    {
        p_action.OnPunch += HandlePunch;
    }

    private void OnDisable()
    {
        p_action.OnPunch -= HandlePunch;
    }

    private void Start()
    {
        ChangeState(idleState);
    }

    private void Update()
    {
        currentState?.UpdateState(this);
    }

    public void ChangeState(PlayerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    private void HandlePunch(PunchType type)
    {
        ChangeState(new PlayerCombatState(type));
    }
}
