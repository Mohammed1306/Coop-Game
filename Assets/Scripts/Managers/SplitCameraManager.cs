using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Example.Prediction.Rigidbodies;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SplitCameraManager : MonoBehaviour
{
    private Camera cam;
    private int nPlayers;

    public string playerName;
    
    public Vector3 offset;
    public float smoothTime = .5f;

    private Vector3 velocity;

    private void Start()
    {
        cam = GetComponent<Camera>();
        nPlayers = PlayersMenu.playersMenu.nPlayers;

        if (nPlayers == 1)
        {
            cam.rect = new Rect(0, 0, 1, 1);
        }

        if (nPlayers == 2)
        {
            if (playerName == "player0")
            {
                cam.rect = new Rect(0,0,0.5f,1);
            }
            else
            {
                cam.rect = new Rect(0.5f,0,0.5f,1);
            }
        }

        if (nPlayers == 3)
        {
            if (playerName == "player0")
            {
                cam.rect = new Rect(0, 0, 0.5f, 1);
            }
            else
            {
                if (playerName == "player1")
                {
                    cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                }
                else
                {
                    cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                }
            }
        }

        if (nPlayers == 4)
        {
            if (playerName == "player0")
            {
                cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            }
            else
            {
                if (playerName == "player1")
                {
                    cam.rect = new Rect(0, 0, 0.5f, 0.5f);
                }
                else
                {
                    if (playerName == "player2")
                    {
                        cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                    }
                    else
                    {
                            cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 newPosition = transform.parent.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }*/
}
