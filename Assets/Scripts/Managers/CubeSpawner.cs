using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;
    private int nPlayers;
    [SerializeField] private Transform[] spawns;
    
    private void Awake()
    {
        nPlayers = PlayersMenu.playersMenu.nPlayers;

        for (int i = 0; i < 5 - nPlayers; i++)
        {
            GameObject myCube =  Instantiate(cube, spawns[i].position, spawns[i].rotation);
            myCube.name = $"cube{i}";
        }
    }
}
