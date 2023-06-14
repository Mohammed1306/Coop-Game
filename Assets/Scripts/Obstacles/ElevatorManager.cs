using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorManager : MonoBehaviour
{
    public int nOnTop = 0;
    private float minHeight = 0;
    public int nPlayers = 1;
    [SerializeField] private float maxHeight;
    [SerializeField] private float speed = 10;
    [SerializeField] private GameObject elevator;

    private void Awake()
    {
        nPlayers = PlayersMenu.playersMenu.nPlayers;
    }

    private void OnTriggerEnter(Collider other)
    {
        nOnTop++;
    }

    private void OnTriggerExit(Collider other)
    {
        nOnTop--;
    }

    // Update is called once per frame
    void Update()
    {
        if (nOnTop == nPlayers && elevator.transform.localPosition.y <= maxHeight)
        {
            elevator.transform.position = new Vector3(elevator.transform.position.x, elevator.transform.position.y + speed * Time.deltaTime,
                elevator.transform.position.z);
        }
        else
        {
            if (elevator.transform.localPosition.y >= minHeight)
            {
                elevator.transform.position = new Vector3(elevator.transform.position.x, elevator.transform.position.y - speed * Time.deltaTime,
                    elevator.transform.position.z);
            }
        }
    }
}
