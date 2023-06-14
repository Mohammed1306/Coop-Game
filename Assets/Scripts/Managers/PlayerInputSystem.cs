using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using UnityEngine.UIElements;


[RequireComponent(typeof(CharacterController))]
public class PlayerInputSystem : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private Vector3 movementInput = Vector2.zero;
    private float rotateInput = 0;
    private bool jumped = false;

    private PlayerInput playerInput;
    private Player playerInputActions;

    public bool gotKey = false;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();


        playerInputActions = new Player();
        playerInputActions.PlayerInput.Enable();

        if (this.name == "player0")
        {
            playerInputActions.PlayerInput.player0.performed += OnMove;
            playerInputActions.PlayerInput.Jump0.performed += OnJump;
        }

        if (this.name == "player1")
        {
            playerInputActions.PlayerInput.player1.performed += OnMove;
            playerInputActions.PlayerInput.Jump1.performed += OnJump;
        }

        if (this.name == "player2")
        {
            playerInputActions.PlayerInput.player2.performed += OnMove;
            playerInputActions.PlayerInput.Jump2.performed += OnJump;
        }

        if (this.name == "player3")
        {
            playerInputActions.PlayerInput.player3.performed += OnMove;
            playerInputActions.PlayerInput.Jump3.performed += OnJump;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (this.name == "player0")
        {
            movementInput = playerInputActions.PlayerInput.player0.ReadValue<Vector2>().y * transform.forward;
            rotateInput = playerInputActions.PlayerInput.player0.ReadValue<Vector2>().x;
        }

        if (this.name == "player1")
        {
            movementInput = playerInputActions.PlayerInput.player1.ReadValue<Vector2>().y * transform.forward;
            rotateInput = playerInputActions.PlayerInput.player1.ReadValue<Vector2>().x;
        }

        if (this.name == "player2")
        {
            movementInput = playerInputActions.PlayerInput.player2.ReadValue<Vector2>().y * transform.forward;
            rotateInput = playerInputActions.PlayerInput.player2.ReadValue<Vector2>().x;
        }

        if (this.name == "player3")
        {
            movementInput = playerInputActions.PlayerInput.player3.ReadValue<Vector2>().y * transform.forward;
            rotateInput = playerInputActions.PlayerInput.player3.ReadValue<Vector2>().x;
        }
    }

    /*public void OnRotate(InputAction.CallbackContext context)
    {
        if (this.name == "player0")
        {
            
            Debug.Log(rotateInput);
        }

        if(this.name == "player1")
            rotateInput = playerInputActions.PlayerInput.player1.ReadValue<Vector2>().x;
        
        if(this.name == "player2")
            rotateInput = playerInputActions.PlayerInput.player2.ReadValue<Vector2>().x;
        
        if(this.name == "player3")
            rotateInput = playerInputActions.PlayerInput.player3.ReadValue<Vector2>().x;
    }*/

    public void OnJump(InputAction.CallbackContext context)
    {
        if (this.name == "player0")
            jumped = playerInputActions.PlayerInput.Jump0.ReadValue<float>() != 0;

        if (this.name == "player1")
            jumped = playerInputActions.PlayerInput.Jump1.ReadValue<float>() != 0;

        if (this.name == "player2")
            jumped = playerInputActions.PlayerInput.Jump2.ReadValue<float>() != 0;

        if (this.name == "player3")
            jumped = playerInputActions.PlayerInput.Jump3.ReadValue<float>() != 0;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.z);
        controller.Move(move.normalized * Time.deltaTime * playerSpeed);

        transform.Rotate(Vector3.up, Time.deltaTime * 100 * rotateInput);


        // Changes the height position of the player..
        if (jumped && groundedPlayer)
        {
            //Debug.Log(this.name);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}