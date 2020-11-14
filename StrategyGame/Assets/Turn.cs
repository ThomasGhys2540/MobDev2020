using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public Text Turntext;

    void Update()
    {
        Turntext.text = "Turns passed: " + PlayerStats.Turn.ToString();
    }

    public void EndTurn()
    {
        PlayerStats.Turn++;
        PlayerStats.Money += 25;
    }
}
