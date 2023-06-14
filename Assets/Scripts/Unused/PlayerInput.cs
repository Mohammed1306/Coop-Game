using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController characterController;
    private int nPlayers;
    private Transform originalTransform;

    private void Awake()
    {
        nPlayers = PlayersMenu.playersMenu.nPlayers;
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        originalTransform = this.transform;
    }

    private void Update()
    {
        /*rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationY;*/
        if (this.name == "player0")
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(0,0,10*Time.deltaTime);
            
            
            if (Input.GetKey(KeyCode.S))
                transform.Translate(0,0,-10*Time.deltaTime);
            
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(Vector3.up,200f * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(Vector3.up,-200f * Time.deltaTime);
        }
        
        if (this.name == "player1")
        {
            if (Input.GetKey(KeyCode.I))
                transform.Translate(0,0,10*Time.deltaTime);
            
            
            if (Input.GetKey(KeyCode.K))
                transform.Translate(0,0,-10*Time.deltaTime);
            
            if (Input.GetKey(KeyCode.L))
                transform.Rotate(Vector3.up,200f * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.J))
                transform.Rotate(Vector3.up,-200f * Time.deltaTime);
        }
        
        if (this.name == "player2")
        {
            if (Input.GetKey(KeyCode.Keypad8))
                transform.Translate(0,0,10*Time.deltaTime);
            
            
            if (Input.GetKey(KeyCode.Keypad5))
                transform.Translate(0,0,-10*Time.deltaTime);
            
            if (Input.GetKey(KeyCode.Keypad6))
                transform.Rotate(Vector3.up,200f * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.Keypad7))
                transform.Rotate(Vector3.up,-200f * Time.deltaTime);
        }
    }
}
