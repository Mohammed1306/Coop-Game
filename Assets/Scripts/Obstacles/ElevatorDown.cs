using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorDown : MonoBehaviour
{
    public int nOnTop = 0;
    private int nPlayers = 1;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private float speed;
    public int playersOnTop;
    [SerializeField] private GameObject elevator;

    private void Awake()
    {
        nPlayers = PlayersMenu.playersMenu.nPlayers;
        maxHeight = elevator.transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "launch")
        {
            other.GameObject().SetActive(false);
        }
        nOnTop++;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            nOnTop--;
    }

    // Update is called once per frame
    void Update()
    {
        if (nOnTop == playersOnTop && elevator.transform.localPosition.y >= minHeight)
        {
            elevator.transform.position = new Vector3(elevator.transform.position.x, elevator.transform.position.y - speed * Time.deltaTime,
                elevator.transform.position.z + 2*speed * Time.deltaTime);
        }
        else
        {
            if (elevator.transform.localPosition.y <= maxHeight)
            {
                elevator.transform.position = new Vector3(elevator.transform.position.x, elevator.transform.position.y + speed * Time.deltaTime,
                    elevator.transform.position.z - 2 * speed * Time.deltaTime);
            }
        }
    }
}
