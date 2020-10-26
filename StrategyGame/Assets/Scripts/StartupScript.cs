using UnityEngine;

public class StartupScript : MonoBehaviour
{
    public Transform Camera;
    public Light Overhead;
    public Transform Tile;
    public Transform Gapfill;
    public Transform Castle;
    public Transform Orientation;
    public Transform Playfield;
    int sideLength = GlobalVariables.FieldSize;
    public Transform[,] playingField;
    public int[] basePos;
    public Material baseTileMaterial;
    public Transform baseTile;
    void Start()
    {
        Tile.localScale = new Vector3(4.75f, 1f, 4.75f);
        playingField = new Transform[sideLength, sideLength];
        for (int y = 0; y < sideLength; y++)
        {
            for (int x = 0; x < sideLength; x++)
            {
                playingField[x,y] = Instantiate(Tile, Orientation.position + new Vector3(x * 5, 0, y * 5), Tile.rotation, Playfield);
            }
        }
        Gapfill.transform.localScale = new Vector3(sideLength * 5 + 1, 0.9f, sideLength * 5 + 1);
        Instantiate(Gapfill, Orientation.position + new Vector3(sideLength * 5f / 2f - 2.5f, 0, sideLength * 5f / 2f - 2.5f), Orientation.rotation, Orientation);

        Overhead.gameObject.transform.position = new Vector3(sideLength / 2 * 5, 50, sideLength / 2 * 5);

        //Camera
        basePos = new int[] { Random.Range(Mathf.CeilToInt(sideLength / 2), sideLength), Random.Range(0, Mathf.FloorToInt(sideLength / 2)) };
        baseTile = playingField[basePos[0], basePos[1]];
        Castle.localScale = new Vector3(5, 5, 100);
        Tile.localScale = new Vector3(0, 0, 0);
        Transform CastleObj = Instantiate(Castle, baseTile.position + new Vector3(-0.25f * baseTile.localScale.x, 1.5f, 0.25f * baseTile.localScale.z), Quaternion.Euler(90, 90, 0), baseTile);
        Camera.position = baseTile.position + new Vector3(0,5,-5);
        Camera.transform.rotation = Quaternion.Euler(45, 0, 0);
        playingField[basePos[0], basePos[1]].GetComponent<MeshRenderer>().material = baseTileMaterial;
            //Configure Camera limits
                //X
        Camera.GetComponent<CameraHandler>().maxmaxX = sideLength * 5 - 5;
        Camera.GetComponent<CameraHandler>().minmaxX = sideLength * 5 - 30;
        Camera.GetComponent<CameraHandler>().maxminX = 25;
        Camera.GetComponent<CameraHandler>().minminX = 0;
                //Z
        Camera.GetComponent<CameraHandler>().maxmaxZ = sideLength * 5 - 10;
        Camera.GetComponent<CameraHandler>().minmaxZ = sideLength * 5 - 25;
        Camera.GetComponent<CameraHandler>().maxminZ = 20;
        Camera.GetComponent<CameraHandler>().minminZ = -5;
    }
}
