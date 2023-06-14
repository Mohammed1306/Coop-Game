using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    private GameObject[] targets;

    public Vector3 offset;
    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;


    private void Awake()
    {
        cam = GetComponent<Camera>();
        targets = GameObject.FindGameObjectsWithTag("Player");
    }

    private void LateUpdate()
    {
        if (targets.Length == 0)
            return;

        Move();
        //Zoom();
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,newZoom,Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for (int i = 0; i < targets.Length; i++)
        {
            bounds.Encapsulate(targets[i].transform.position);
        }

        return bounds.size.z;
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0,newPosition.y,newPosition.z), ref velocity, smoothTime);
    }

    private Vector3 GetCenterPoint()
    {
        if (targets.Length == 1)
            return targets[0].transform.position;

        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for (int i = 0; i < targets.Length; i++)
        {
            bounds.Encapsulate(targets[i].transform.position);
        }

        return bounds.center;
    }


    /*[SerializeField] private GameObject camera;
    private GameObject[] players;
    private float z;
    private float max;
    private float min;

    private void Awake()
    {
        camera.transform.rotation = Quaternion.Euler(50,0,0);
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    

    private void Update()
    {
        z = players.Length == 0 ? players[0].transform.position.z: FindNewZ();
        
        camera.transform.position = new Vector3(0, 7.5f,z - 5);
    }

    private float FindNewZ()
    {
        max = players[0].transform.position.z;
        min = players[0].transform.position.z;
        for (int i = 1; i < players.Length; i++)
        {
            max = Mathf.Max(max, players[i].transform.position.z);
            min = Mathf.Min(min, players[i].transform.position.z);
        }

        return (max + min) / 2;
    }*/
}
