using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject bridge;
    [SerializeField] private GameObject button;
    private Material[] mats;
    private GameObject[] players;
    private int random;
    
    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        bridge.SetActive(false);

        Random rnd = new Random();
        random = rnd.Next(0, players.Length);

        button.GetComponentInChildren<MeshRenderer>().material = players[random].GetComponentInChildren<MeshRenderer>().material;
        button.GetComponentInChildren<MeshRenderer>().material.name = players[random].name;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GameObject() == players[random])
        {
            bridge.SetActive(true);
            button.transform.position = new Vector3(button.transform.position.x,button.transform.position.y - 0.2f,button.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GameObject() == players[random])
        {
            bridge.SetActive(false);
            button.transform.position = new Vector3(button.transform.position.x,button.transform.position.y + 0.2f,button.transform.position.z);

        }
    }
}
