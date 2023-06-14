using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] help;

    
    void Awake()
    {
        for (int i = 0; i < help.Length; i++)
        {
            help[i].SetActive(false);
        }

        if (PlayersMenu.playersMenu.nPlayers == 1)
        {
            for (int i = 0; i < help.Length; i++)
            {
                help[i].SetActive(true);
            }
        }
    }
}
