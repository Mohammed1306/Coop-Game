using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//This is made by Bobsi Unity - Youtube
public class PlayerController : MonoBehaviour
{
    [Header("Base setup")]
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float rotatespeed = 1;
    public float turnspeed = 1;
 
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
 
    [HideInInspector]
    public bool canMove = true;
 
    [SerializeField]
    private float cameraYOffset = 0.4f;
    [SerializeField]
    private float cameraZOffset = 0.4f;
    private Camera playerCamera;

    [SerializeField] private float speed = 10;
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
 
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        playerCamera = Camera.main;
        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + cameraYOffset, transform.position.z + cameraZOffset);
        playerCamera.transform.localRotation = Quaternion.Euler(30, 0, 0);
        playerCamera.transform.SetParent(transform);
    }
 
    void Update()
    {
        bool isRunning = false;
 
        // Press Left Shift to run
        isRunning = Input.GetKey(KeyCode.LeftShift);
 
        // We are grounded, so recalculate move direction based on axis
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
 
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
 
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
 
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
 
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.E))

   
            transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.Q))
   
            transform.Rotate(Vector3.up, -rotatespeed * Time.deltaTime);
    }
}