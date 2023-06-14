using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Wall2 : MonoBehaviour
{
    [SerializeField] private float maxZ;
    [SerializeField] private float minZ;
    [SerializeField] private bool isMoving = false;
    //[SerializeField] private GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        isMoving = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isMoving = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                minZ);
        }
    }
}

