using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisappearBlocks : MonoBehaviour
{
    public GameObject block;
    private float tempsÉcoulé;
    private float maxtemps = .5f;

    private bool isOnTop = false;

    private void OnTriggerEnter(Collider other)
    {
        isOnTop = true;
    }

    private void Update()
    {
        if (isOnTop)
        {
            tempsÉcoulé += Time.deltaTime;
            if (tempsÉcoulé > maxtemps)
            {
                block.GetComponent<MeshRenderer>().enabled = false;
                block.GetComponent<BoxCollider>().enabled = false;
            }
            if (tempsÉcoulé > 4 * maxtemps)
            {
                block.GetComponent<MeshRenderer>().enabled = true;
                block.GetComponent<BoxCollider>().enabled = true;
                tempsÉcoulé = 0;
                isOnTop = false;
            }
        }
    }
}
