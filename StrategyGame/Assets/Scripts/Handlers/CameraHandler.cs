using System;
using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour
{
    private static readonly float ZoomSpeedTouch = 0.001f;
    private static readonly float ZoomSpeedMouse = 0.5f;

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

    public /*static*/ float[] BoundsX = new float[] { -10f, 5f };
    public /*static*/ float[] BoundsZ = new float[] { -18f, -4f };

    private Camera cam;

    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only

    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only

    private Vector3 dragOrigin;
    bool panning = false;

    void Awake()
    {
        cam = GetComponent<Camera>();
        BoundsX[0] = minminX;
        BoundsX[1] = maxmaxX;
        BoundsZ[0] = minminZ;
        BoundsZ[1] = maxmaxZ;
    }

    void Update()
    {
        if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            HandleTouch();
        }
        else
        {
            HandleMouse();
        }
    }

    void HandleTouch()
    {
        switch (Input.touchCount)
        {

            case 1: // Panning
                wasZoomingLastFrame = false;

                PanCamera();
                break;

            case 2: // Zooming
                panning = false;
                Vector2[] newPositions = new Vector2[] { Input.GetTouch(0).position, Input.GetTouch(1).position };
                if (!wasZoomingLastFrame)
                {
                    lastZoomPositions = newPositions;
                    wasZoomingLastFrame = true;
                }
                else
                {
                    // Zoom based on the distance between the new positions compared to the 
                    // distance between the previous positions.
                    float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
                    float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
                    float offset = newDistance - oldDistance;

                    ZoomCamera(offset, ZoomSpeedTouch);

                    lastZoomPositions = newPositions;
                }
                break;

            default:
                wasZoomingLastFrame = false;
                panning = false;
                break;
        }
    }

    void HandleMouse()
    {
        // On mouse down, capture it's position.
        // Otherwise, if the mouse is still down, pan the camera.
        if (Input.GetMouseButton(0))
        {
            PanCamera();
        }
        else
        {
            panning = false;
        }

        // Check for scrolling to zoom the camera
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll, ZoomSpeedMouse);
    }

    void PanCamera()
    {
        Vector3 pos = transform.position;
        if (!panning)    //If Left mouse button gets pressed, get position
        {
            dragOrigin = GetMousePos();
            panning = true;
        }

        if (panning) //While left mouse button is kept pressed
        {
            Vector3 currPos = GetMousePos();

            Vector3 move = dragOrigin - currPos;    //Calculate position difference
            move.y = 0; //Set y component to 0
            pos = pos + move; //Set position to original + the difference
        }

        if (pos.x < BoundsX[0])  //Keep X in range
        {
            pos.x = BoundsX[0];
        }
        else if (pos.x > BoundsX[1])
        {
            pos.x = BoundsX[1];
        }

        if (pos.z < BoundsZ[0])  //Keep Z in range
        {
            pos.z = BoundsZ[0];
        }
        else if (pos.z > BoundsZ[1])
        {
            pos.z = BoundsZ[1];
        }
        transform.position = pos;
    }

    void ZoomCamera(float offset, float speed)
    {
        if (offset == 0)
        {
            return;
        }

        Vector3 pos = transform.position;
        pos.y -= offset * 1000f * speed * Time.deltaTime;

        if (pos.y < minY)   //Keep Y in range
        {
            pos.y = minY;
        }
        if (pos.y > maxY)
        {
            pos.y = maxY;
        }

        // Original formula was: A + Math.Pow((Y - minY)/(maxY - minY), 2) * (Y - minY) * ((maxA - minA)/(maxY - minY))

        BoundsX[0] = minminX + (float)Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxminX - minminX);
        BoundsX[1] = maxmaxX - (float)Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxmaxX - minmaxX);
        BoundsZ[0] = minminZ + (float)Math.Pow((pos.y - minY) / (maxY - minY), 3) * (maxminZ - minminZ);
        BoundsZ[1] = minmaxZ + (float)Math.Pow((maxY - pos.y) / (maxY - minY), 3) * (maxmaxZ - minmaxZ);

        if (pos.x < BoundsX[0])  //Keep X in range
        {
            pos.x = BoundsX[0];
        }
        else if (pos.x > BoundsX[1])
        {
            pos.x = BoundsX[1];
        }

        if (pos.z < BoundsZ[0])  //Keep Z in range
        {
            pos.z = BoundsZ[0];
        }
        else if (pos.z > BoundsZ[1])
        {
            pos.z = BoundsZ[1];
        }

        transform.transform.rotation = Quaternion.Euler(45 + (pos.y - minY) * (45 / (maxY - minY)), 0, 0);
        transform.position = pos;
    }

    private Vector3 GetMousePos()   //Get mouse world position
    {
        Plane plane = new Plane(Vector3.up, 0); //Create plane
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //Create ray from camera through mouse
        if (plane.Raycast(ray, out distance))   //If they intersect
        {
            return ray.GetPoint(distance);    //Get location of intersect
        }
        return new Vector3(0, 0, 0);
    }
}