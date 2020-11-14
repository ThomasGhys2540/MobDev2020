using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Cavalry : IUnit
{
    public override float health { get; set; }
    public override float power { get; set; }
    public override int movement { get; set; }
    public override AbilityType ability { get; set; }
    public override bool abilityActive { get; set; }
    public override Point point { get; set; }

    public Cavalry(Point tile)
    {
        health = 120;
        power = 10;
        movement = 2;
        ability = AbilityType.Stampede;
        abilityActive = false;
        point = tile;
    }

    public override void Move(Point tile)
    {
        point = tile;
    }

    public override void Attack(IUnit enemy)
    {
        if (!abilityActive)
            enemy.GetAttacked(power, this);
        else
            enemy.GetAttacked(power * 2, this);
    }

    public override void GetAttacked(float damage, IUnit enemy)
    {
        health -= damage;
        enemy.Recoil(power, this);
    }

    public override void Recoil(float damage, IUnit enemy = null)
    {
        health -= damage;
        if (abilityActive)
        {
            abilityActive = false;
            health *= 2;
        }
    }

    public override void Ability()
    {
        abilityActive = !abilityActive;
        health /= 2;
    }
}
