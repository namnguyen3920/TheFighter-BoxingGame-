using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharController : MonoBehaviour
{
    public AnimationController anim_controller;
    public HitReceiver _hitReceiver;
    public PowerSlider powerSlider;
    public HealthMN healthMN;
    public CharacterStats characterStats;

    public Dictionary<CharacterAction, IPowerScaler> _charRegistry = new ();
    public CharacterAction _charCurrAction;

    [Header("Character State")]
    public CharacterBaseState characterCurrentState;
    public CharacterIdleState characterIdleState;
    public CharacterCombatState characterCombatState;
    public CharacterBeingHitState characterBeingHitState;
    public CharacterKnockOutState characterKnockOutState;

    protected virtual void Awake()
    {
        _hitReceiver = GetComponentInChildren<HitReceiver>();
        anim_controller = GetComponentInChildren<AnimationController>();
        healthMN = GetComponentInChildren<HealthMN>();

        characterIdleState = new CharacterIdleState();
        characterCombatState = new CharacterCombatState();
        characterBeingHitState = new CharacterBeingHitState();
        characterKnockOutState = new CharacterKnockOutState();

        CharacterChangeState(characterIdleState);

        var enemySlider = GameObject.FindWithTag(gameObject.tag + "Slider");
        if (enemySlider != null)
        {
            powerSlider = enemySlider.GetComponent<PowerSlider>();
        }
    }

    protected virtual void Update()
    {
        characterCurrentState?.UpdateState(this);
    }

    public void CharacterChangeState(CharacterBaseState characterNewState)
    {
        characterCurrentState?.ExitState(this);
        characterCurrentState = characterNewState;
        characterCurrentState.EnterState(this);
    }

    public void HandleCharacterAction(CharacterAction action)
    {
        _charCurrAction = action;
        SetCurrentCharacterAction(_charCurrAction);

        var actionScalerType = _charRegistry[action];
        powerSlider.RegisterPowerScaler(actionScalerType);
        powerSlider.SliderNotify();
        float actualValue = actionScalerType.ActualValue;

        CharController opponent;
        if (GameManager.d_Instance.player == this)
        {
            opponent = GameManager.d_Instance.enemy;
        }
        else
        {
            opponent = GameManager.d_Instance.player;
        }


        GameManager.d_Instance.AssignAction(new ActionProperties(this, _charCurrAction, actualValue, opponent));

        powerSlider.UnregisterPowerScaler(actionScalerType);
    }



    public void SetCurrentCharacterAction(CharacterAction action)
    {
        this._charCurrAction = action;
    }
}
