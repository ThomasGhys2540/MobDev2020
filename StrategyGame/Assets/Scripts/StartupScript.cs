using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class StartupScript : MonoBehaviour
{
    public Transform Tile;
    public Transform Orientation;
    public int sideLength = 20;
    public Transform[,] playingField;
    void Start()
    {
        playingField = new Transform[sideLength, sideLength];
        for (int y = 0; y < sideLength; y++)
        {
            for (int x = 0; x < sideLength; x++)
            {
                playingField[x,y] = Instantiate(Tile, Orientation.position + new Vector3(x * 5, 0, y * 5), Tile.rotation, Orientation);
            }
        }
    }
}
