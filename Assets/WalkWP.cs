﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkWP : MonoBehaviour
{
	public GameObject[] path;

    private Vector3 goal;
    private float speed = 4.0f;
    private float accuracy = 0.5f;
    private float rotSpeed = 4f;

    private int curNode = 0;

    void LateUpdate()
    {
        // set the goal position
        goal = new Vector3(path[curNode].transform.position.x,
                            this.transform.position.y,
                            path[curNode].transform.position.z);

        // set the direction
        Vector3 direction = goal - this.transform.position;

        // move toward the goal or increase the counter to set another goal in the next iteration
        if (direction.magnitude > accuracy)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else
        {
            if (curNode < path.Length - 1)
            {
                curNode++;
            }
            else
            {
            	curNode = 0;
            }
        }
    }
}
