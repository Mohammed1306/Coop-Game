using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    private int nPlayers;
    [SerializeField] private Transform[] spawns;
    [SerializeField] private Material[] mats;
    
    private void Awake()
    {
        nPlayers = PlayersMenu.playersMenu.nPlayers;

        for (int i = 0; i < nPlayers; i++)
        {
            GameObject myPlayers =  Instantiate(player, spawns[i].position, spawns[i].rotation);
            myPlayers.transform.name = $"player{i}";
            myPlayers.GetComponentInChildren<SplitCameraManager>().playerName = $"player{i}";
            myPlayers.tag = "Player";
            myPlayers.GetComponentInChildren<MeshRenderer>().material = mats[i];
            if (i == 0)
                myPlayers.AddComponent(typeof(AudioListener));
        }
    }
    
}
