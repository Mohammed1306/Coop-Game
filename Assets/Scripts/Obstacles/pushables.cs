using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class pushables : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    public int nTriggers;
    [SerializeField] private bool nPlayers;
    public int triggering;
    [SerializeField] private float speed;
    
    private void Start()
    {
        if(nPlayers)
            nTriggers = PlayersMenu.playersMenu.nPlayers;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        triggering++;
    }

    private void OnTriggerExit(Collider other)
    {
        triggering--;
    }

    private void Update()
    {
        if (triggering == nTriggers)
        {
            wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y,
                wall.transform.position.z + speed * Time.deltaTime);
        }
    }
}
