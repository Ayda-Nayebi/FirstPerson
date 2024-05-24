using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{ 
    public static PlayerManager Instance;

    private CharacterController characterController;
    private Vector3 playerVelocity;
   
    private bool isGrounded;


    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [HideInInspector] private float gravity = -9.8f;

    private void Start()
    {
        Instance = this;
        GetComponents();
    }

    private void Update()
    {
        isGrounded= characterController.isGrounded;
    }
    private void GetComponents()
    {
        characterController = GetComponent<CharacterController>();
    }



    // recive inputs from inputManager.cs and apply it to charechter controller.
    public void MovementProcessor(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        characterController.Move(transform.TransformDirection(moveDirection)* speed* Time.deltaTime);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity* Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
