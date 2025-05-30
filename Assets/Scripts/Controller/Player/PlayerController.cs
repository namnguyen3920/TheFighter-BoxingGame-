using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerController : CharController
{
    [SerializeField] CharacterStats _player;
    public PlayerInputMN p_action;

    protected override void Awake()
    {
        base.Awake();
        _charRegistry = new Dictionary<CharacterAction, IPowerScaler>()
        {
            { CharacterAction.Attack, new PlayerAttackScaler(this, _player.Damage) },
            { CharacterAction.Block, new PlayerBlockScaler(this, _player.Endurance) },
        };
    }

    private void HandlePlayerClicked(CharacterAction action)
    {
        p_action.DisableInput();

        HandleCharacterAction(action);
    }

    private void OnEnable()
    {
        p_action.OnClicked += HandlePlayerClicked;
    }

    private void OnDisable()
    {
        p_action.OnClicked -= HandlePlayerClicked;
    }
}
