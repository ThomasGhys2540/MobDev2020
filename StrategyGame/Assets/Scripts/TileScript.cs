using System;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;

    private Renderer rend;
    private GameObject unit;
    private bool isClicked = false;
    private DateTime startClick;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = baseColor;
    }

    private void OnMouseDown()
    {
        isClicked = true;
        startClick = DateTime.Now;
    }

    private void OnMouseUp()
    {
        /*if (isClicked)
        {
            if ((DateTime.Now - startClick).TotalMilliseconds <= 300)
            {
                if (BuildManager.instance.isBase(transform))
                {

                }    
            }

            isClicked = false;
        }*/
    }
}
