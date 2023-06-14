using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchersManager : MonoBehaviour
{
    private bool isOnTop = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].otherCollider.tag == "Player")
        {
            transform.position = new Vector3(collision.contacts[0].otherCollider.transform.position.x, collision.contacts[0].otherCollider.transform.position.y + 1,
                collision.contacts[0].otherCollider.transform.position.z);
        }
    }
    
}
