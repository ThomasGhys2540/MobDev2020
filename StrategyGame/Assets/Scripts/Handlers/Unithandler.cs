using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Unithandler : MonoBehaviour
{
    static List<IUnit> playerUnits = new List<IUnit>();
    static List<IUnit> enemyUnits = new List<IUnit>();
    static IUnit[,] playfield = new IUnit[GlobalVariables.FieldSize, GlobalVariables.FieldSize];

    [Header("Magicka Variables")]
    public static int healingValue = 20;
    public static int HPCooldown = 5;

    public static void Move(IUnit unit, Point toPoint)
    {
        playfield[toPoint.Y, toPoint.X] = unit;
        playfield[unit.point.Y, unit.point.X] = null;
        unit.point = toPoint;
    }

    public static void Volley(Archer archer)
    {
        Dummy dummy = new Dummy(archer.point);

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                try
                {
                    if(playfield[archer.point.Y - 1 + y, archer.point.X - 1 + x] != archer)
                        playfield[archer.point.Y - 1 + y, archer.point.X - 1 + x].GetAttacked(archer.power, dummy);
                }
                catch { }
            }
        }

        archer.Recoil(dummy.health);
    }

    public static void Healing_Pulse(Magicka magicka)
    {
        if (magicka.HPCooldown <= 0)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    try
                    {
                        playfield[magicka.point.Y - 2 + y, magicka.point.X - 2 + x].health += healingValue;
                    }
                    catch { }
                }
            }
            magicka.HPCooldown = HPCooldown;
        }
    }
}
