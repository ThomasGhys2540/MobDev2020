using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
   public void Select(int levelSize)
    {
        GlobalVariables.FieldSize = levelSize;
        SceneManager.LoadScene("Level");
    }
}
