using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueCounter : MonoBehaviour
{
    public Text coinText;

    void Update()
    {
        coinText.text = PlayerStats.Money.ToString();
    }
}
