using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    public float rotSpeed;
    public float speed;
    public float radius = 1;
    void Update()
    {
       if(Vector3.Distance(waypoints[current].transform.position, transform.position) < radius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }

}
