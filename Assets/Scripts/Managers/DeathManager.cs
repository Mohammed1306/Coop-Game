using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    private GameObject player;
    public GameObject spawn;
    private Vector3 deathPosition;
    private int nearestSpawn;

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        deathPosition = other.transform.position;
        nearestSpawn = ClosestSpawn();
        other.transform.position = spawnPoints[nearestSpawn].transform.position;
    }

    private int ClosestSpawn()
    {
        int closest = 0;
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            if (CalculDistance(spawnPoints[i].transform.position, deathPosition) <
                CalculDistance(spawnPoints[i - 1].transform.position, deathPosition) 
                && player.transform.position.z >= spawnPoints[i].transform.position.z)
                closest = i;
        }

        return closest;
    }

    private float CalculDistance(Vector3 a, Vector3 b)
        => Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.z - b.z, 2));
}
