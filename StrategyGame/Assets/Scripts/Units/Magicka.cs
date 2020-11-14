using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Magicka : IUnit
{
    public override float health { get; set; }
    public override float power { get; set; }
    public override int movement { get; set; }
    public override AbilityType ability { get; set; }
    public override bool abilityActive { get; set; }
    public override Point point { get; set; }
    public int HPCooldown { get; set; }

    public Magicka(Point tile)
    {
        health = 80;
        power = 25;
        movement = 1;
        ability = AbilityType.Healing_Pulse;
        abilityActive = false;
        point = tile;
        HPCooldown = 0;
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
            throw new NotImplementedException();
    }

    public override void GetAttacked(float damage, IUnit enemy)
    {
        health -= damage;
        enemy.Recoil(power, this);
    }

    public override void Recoil(float damage, IUnit enemy = null)
    {
        if (enemy.ability == AbilityType.Volley)
            health -= damage;
    }

    public override void Ability()
    {
        abilityActive = !abilityActive;
    }
}
