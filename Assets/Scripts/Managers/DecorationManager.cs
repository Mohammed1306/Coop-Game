using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DecorationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] Transform[] spawns;

    private Random rndPrefab;
    private Random rndSpawn;

    private float tpsÉcoulé = 0;

    private float tpsRequis = 3;

    private void Awake()
    {
        rndPrefab = new Random();
        rndSpawn = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        tpsÉcoulé += Time.deltaTime;

        if (tpsÉcoulé > tpsRequis)
        {
            GameObject decoration = Instantiate(prefabs[rndPrefab.Next(0, prefabs.Length)],
                spawns[rndSpawn.Next(0, spawns.Length)].position,spawns[rndSpawn.Next(0, spawns.Length)].rotation);
            Destroy(decoration,60f);
            tpsÉcoulé = 0;
        }
    }
}
