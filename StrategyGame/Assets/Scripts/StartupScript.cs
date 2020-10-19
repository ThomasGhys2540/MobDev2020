using UnityEngine;

public class StartupScript : MonoBehaviour
{
    public Transform Camera;
    public Transform Tile;
    public Transform Gapfill;
    public Transform Orientation;
    public Transform Playfield;
    public int sideLength = 15;
    public Transform[,] playingField;
    public int[] basePos;
    void Start()
    {
        playingField = new Transform[sideLength, sideLength];
        for (int y = 0; y < sideLength; y++)
        {
            for (int x = 0; x < sideLength; x++)
            {
                playingField[x,y] = Instantiate(Tile, Orientation.position + new Vector3(x * 5, 0, y * 5), Tile.rotation, Playfield);
            }
        }
        Gapfill.transform.localScale = new Vector3(sideLength * 5 + 1, 0.9f, sideLength * 5 + 1);
        Instantiate(Gapfill, Orientation.position + new Vector3(sideLength * 5 / 2 - 2, 0, sideLength * 5 / 2 - 2), Orientation.rotation, Orientation);
        basePos = new int[] { Random.Range(0, sideLength), Random.Range(0, sideLength) };
        Camera.position = playingField[basePos[0], basePos[1]].position + new Vector3(0,5,-5);
    }
}
