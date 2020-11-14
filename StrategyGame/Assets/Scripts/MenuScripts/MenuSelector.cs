using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public void Play(string menu)
    {
        SceneManager.LoadScene(menu);
    }
}
