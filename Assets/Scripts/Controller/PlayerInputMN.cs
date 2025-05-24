using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMN : MonoBehaviour
{
    [SerializeField] private PlayerInputAction p_input;

    public event Action<PunchType> OnPunch;

    private void Awake()
    {
        p_input = new PlayerInputAction();
    }

    private void OnEnable()
    {
        p_input.Enable();
        p_input.PlayerInput.PunchLeft.performed += OnPunchLeft;
        p_input.PlayerInput.PunchRight.performed += OnPunchRight;
        p_input.PlayerInput.PunchStraight.performed += OnPunchStraight;
    }

    private void OnDisable()
    {
        p_input.PlayerInput.PunchLeft.performed -= OnPunchLeft;
        p_input.PlayerInput.PunchRight.performed -= OnPunchRight;
        p_input.PlayerInput.PunchStraight.performed -= OnPunchStraight;

        p_input.Disable();
    }

    private void OnPunchLeft(InputAction.CallbackContext context) => OnPunch?.Invoke(PunchType.PunchLeft);
    private void OnPunchRight(InputAction.CallbackContext context) => OnPunch?.Invoke(PunchType.PunchRight);
    private void OnPunchStraight(InputAction.CallbackContext context) => OnPunch?.Invoke(PunchType.PunchStraight);

}
