using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFootActions;

  

    private void Awake()
    {
        Instance=this;
        NewPlayerInput();
        JumpCallBAck();

    }
    private void FixedUpdate()
    {
        //tell player manager to move using the value from movment action.
        PlayerManager.Instance.MovementProcessor(onFootActions.Movement.ReadValue<Vector2>());
    }


    private void LateUpdate()
    {
       PlayerLookController.Instance.LookProccessor(onFootActions.LoockAround.ReadValue<Vector2>());
    }



    private void NewPlayerInput()
    {
        playerInput = new PlayerInput();
        onFootActions = playerInput.OnFoot;
    }

    private void OnEnable()
    {
        onFootActions.Enable();
    }

    private void OnDisable()
    {
        onFootActions.Disable();
    }

    private void JumpCallBAck()
    {
        onFootActions.Jump.performed += ctx => PlayerManager.Instance.Jump();
    }
}
