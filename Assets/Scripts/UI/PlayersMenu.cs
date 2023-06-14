using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayersMenu : MonoBehaviour
{
    public static PlayersMenu playersMenu;

    public int nPlayers;

    [SerializeField] private bool lastScene;

    private void Awake()
    {
        if (playersMenu == null)
        {
            playersMenu = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(lastScene ? SceneManager.sceneCountInBuildSettings - 1 : SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void OnePlayer()
    {
        nPlayers = 1;
    }
    
    public void TwoPlayers()
    {
        nPlayers = 2;
    }
    
    public void ThreePlayers()
    {
        nPlayers = 3;
    }
    
    public void FourPlayers()
    {
        nPlayers = 4;
    }
}
