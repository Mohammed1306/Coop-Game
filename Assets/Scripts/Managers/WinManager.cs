using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject player;
    private int nb = 0;
    private int nPlayers;
    public bool needsKey = false;
    private bool isUnlocked = false;
    public GameObject key;

    private void Awake()
    {
        nPlayers = PlayersMenu.playersMenu.nPlayers;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (needsKey)
        {
            if (other.tag == "Player" && key.GetComponentInChildren<KeyManager>().player == other.name)
            {
                isUnlocked = true;
                key.SetActive(false);
            }
        }
        else
        {
            isUnlocked = true;
        }

        if (isUnlocked)
        {
            nb++;
            for (int i = 0; i < other.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                other.GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
            }
            for (int i = 0; i < other.GetComponentsInChildren<BoxCollider>().Length; i++)
            {
                other.GetComponentsInChildren<BoxCollider>()[i].isTrigger = true;
            }

            if (nb == nPlayers)
            {
                Debug.Log("win");
                Win();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < other.GetComponentsInChildren<MeshRenderer>().Length; i++)
        {
            other.GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
        }
        for (int i = 0; i < other.GetComponentsInChildren<BoxCollider>().Length; i++)
        {
            other.GetComponentsInChildren<BoxCollider>()[i].isTrigger = false;
        }
        nb--;
    }
    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
