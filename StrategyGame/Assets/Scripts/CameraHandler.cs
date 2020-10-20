﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private bool doMovement = true;
    public float panspeed = 20f;
    public float scrollSpeed = 5f;

    [Header("Coordinate Limits")]

    public float minminX = 0;
    public float maxminX = 25;

    public float maxmaxX = 70;
    public float minmaxX = 45;

    [Space(10)]

    public float minY = 5;
    public float maxY = 45;

    [Space(10)]

    public float minminZ = -5;
    public float maxminZ = 20;

    public float maxmaxZ = 65;
    public float minmaxZ = 50;

    void Update()
    {
        if(Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                doMovement = !doMovement;
            }

            if (!doMovement)
            {
                return;
            }

            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * panspeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.back * panspeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * panspeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * panspeed * Time.deltaTime, Space.World);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000f * scrollSpeed * Time.deltaTime;
        if(pos.y < minY)   //Keep Y in range
        {
            pos.y = minY;
        }
        if(pos.y > maxY)
        {
            pos.y = maxY;
        }

        // Original formula was: A + Math.Pow((Y - minY)/(maxY - minY), 2) * (Y - minY) * ((maxA - minA)/(maxY - minY))

        if(pos.x < minminX + Math.Pow((pos.y - minY)/(maxY - minY), 3) * (maxminX - minminX))  //Keep X in range
        {
            pos.x = minminX + (float)Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxminX - minminX);
        }
        if (pos.x > maxmaxX - Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxmaxX - minmaxX))
        {
            pos.x = maxmaxX - (float)Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxmaxX - minmaxX);
        }

        if(pos.z < minminZ + Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxminZ - minminZ)) //Keep Z in range
        {
            pos.z = minminZ + (float)Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxminZ - minminZ);
        }
        if (pos.z > maxmaxZ - Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxmaxZ - minmaxZ))
        {
            pos.z = maxmaxZ - (float)Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxmaxZ - minmaxZ);
        }

        transform.transform.rotation = Quaternion.Euler(45 + (pos.y - 5)*(45f / 40f), 0, 0);
        transform.position = pos;
    }
}
