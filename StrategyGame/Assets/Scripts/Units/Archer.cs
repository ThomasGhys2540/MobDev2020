using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using System.Drawing;

public class Archer : IUnit
{
    public override float health { get; set; }
    public override float power { get; set; }
    public override int movement { get; set; }
    public override AbilityType ability { get; set; }
    public override bool abilityActive { get; set; }
    public override Point point { get; set; }
    public Archer(Point tile)
    {
        health = 100;
        power = 20;
        movement = 1;
        ability = AbilityType.Volley;
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
            Unithandler.Volley(this);
    }

    public override void GetAttacked(float damage, IUnit enemy)
    {
        health -= damage;
        enemy.Recoil(power, this);
    }

    public override void Recoil(float damage, IUnit enemy = null)
    {
        if(abilityActive || enemy.ability == AbilityType.Healing_Pulse)
        {
            health -= damage;
            abilityActive = false;
        }
    }

    public override void Ability()
    {
        abilityActive = !abilityActive;
    }
}
