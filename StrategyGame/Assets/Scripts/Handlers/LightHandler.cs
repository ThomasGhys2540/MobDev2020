
using UnityEngine;

public class LightHandler : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
    }
}
