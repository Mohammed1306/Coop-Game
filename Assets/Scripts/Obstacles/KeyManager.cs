using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private GameObject target;
    private bool gotKey = false;
    public string player;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = GameObject.Find(other.name);
            gotKey = true;
            player = target.name;
        }
    }

    private void Update()
    {
        if(gotKey)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y,
            target.transform.position.z + 1);
            
        }
    }
}
