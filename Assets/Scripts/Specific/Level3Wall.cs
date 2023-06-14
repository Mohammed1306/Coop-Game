using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Wall : MonoBehaviour
{
    [SerializeField] private float maxZ;
    [SerializeField] private float minY;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= maxZ)
        {
            if (transform.position.y >= minY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime,
                    maxZ);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, minY,
                    maxZ);
            }
        }
    }
}
