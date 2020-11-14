using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Melee : IUnit
{
    public override float health { get; set; }
    public override float power { get; set; }
    public override int movement { get; set; }
    public override AbilityType ability { get; set; }
    public override bool abilityActive { get; set; }
    public override Point point { get; set; }

    public Melee(Point tile)
    {
        health = 100;
        power = 20;
        movement = 1;
        ability = AbilityType.Reckless_Charge;
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
            enemy.GetAttacked(power * 1.5f, this);
    }

    public override void GetAttacked(float damage, IUnit enemy)
    {
        health -= damage;
        enemy.Recoil(power);
    }

    public override void Recoil(float damage, IUnit enemy = null)
    {
        if (!abilityActive)
            health -= damage;
        else
            health -= damage * 1.5f;
    }

    public override void Ability()
    {
        abilityActive = !abilityActive;
    }
}
