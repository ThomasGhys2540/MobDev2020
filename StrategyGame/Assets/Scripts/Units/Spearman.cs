using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Spearman : IUnit
{
    public override float health { get; set; }
    public override float power { get; set; }
    public override int movement { get; set; }
    public override AbilityType ability { get; set; }
    public override bool abilityActive { get; set; }
    public override Point point { get; set; }

    public Spearman(Point tile)
    {
        health = 100;
        power = 20;
        movement = 1;
        ability = AbilityType.Spear_Wall;
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
        health -= damage;
        enemy.Recoil(power * 1.5f, this);
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
            health += 20;
            movement -= 1;
        }
        else
        {
            health -= 20;
            movement += 1;
        }
    }
}
