using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Unity.VisualScripting;

public class Lvl4Button : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private GameObject button;
    private Material[] mats;
    private GameObject[] players;
    private int random;
    
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }

        Random rnd = new Random();
        random = rnd.Next(0, players.Length);

        button.GetComponentInChildren<MeshRenderer>().material = players[random].GetComponentInChildren<MeshRenderer>().material;
        button.GetComponentInChildren<MeshRenderer>().material.name = players[random].name;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GameObject() == players[random])
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(true);
            }
            
            button.transform.position = new Vector3(button.transform.position.x,button.transform.position.y - 0.2f,button.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GameObject() == players[random])
        {
            button.transform.position = new Vector3(button.transform.position.x,button.transform.position.y + 0.2f,button.transform.position.z);
        }
    }
}
