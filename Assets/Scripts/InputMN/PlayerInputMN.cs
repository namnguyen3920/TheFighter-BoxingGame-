using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMN : MonoBehaviour
{
    [SerializeField] private PlayerInputAction p_input;

    public event Action<CharacterAction> OnClicked;

    private void Awake()
    {
        p_input = new PlayerInputAction();
    }

    private void OnEnable()
    {
        p_input.Enable();
        p_input.PlayerInput.Attack.performed += OnAttack;
        p_input.PlayerInput.Block.performed += OnBlock;
    }

    private void OnDisable()
    {
        p_input.PlayerInput.Attack.performed -= OnAttack;
        p_input.PlayerInput.Block.performed -= OnBlock;

        p_input.Disable();
    }

    public void EnableInput()
    {
        p_input.Enable();
    }
    public void DisableInput()
    {
        p_input.Disable();
    }
    private void OnAttack(InputAction.CallbackContext context) => OnClicked?.Invoke(CharacterAction.Attack);
    private void OnBlock(InputAction.CallbackContext context) => OnClicked?.Invoke(CharacterAction.Block);

}
