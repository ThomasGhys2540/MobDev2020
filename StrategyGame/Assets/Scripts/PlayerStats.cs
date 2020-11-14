using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int MaximumTroopCount;
    public static int Turn;

    private int startTurn = 0;
    private int startMoney = 500;

    private void Awake()
    {
        Money = startMoney;
        Turn = startTurn;
    }
}
