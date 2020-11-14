using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Shield : IUnit
{
    public override float health { get; set; }
    public override float power { get; set; }
    public override int movement { get; set; }
    public override AbilityType ability { get; set; }
    public override bool abilityActive { get; set; }
    public override Point point { get; set; }

    public Shield(Point tile)
    {
        health = 140;
        power = 10;
        movement = 1;
        ability = AbilityType.Fortify;
        abilityActive = false;
        point = tile;
    }

    public override void Move(Point tile)
    {
        point = tile;
    }

    public override void Attack(IUnit enemy)
    {
        enemy.GetAttacked(power, this);
    }

    public override void GetAttacked(float damage, IUnit enemy)
    {
        health -= damage * 0.5f;
        if (abilityActive)
            enemy.Recoil(power * 1.5f, this);
        else
            enemy.Recoil(power, this);
    }

    public override void Recoil(float damage, IUnit enemy = null)
    {
        health -= damage;
    }

    public override void Ability()
    {
        abilityActive = !abilityActive;
        if(abilityActive)
        {
            movement -= 1;
        }
        else
        {
            movement += 1;
        }
    }
}
