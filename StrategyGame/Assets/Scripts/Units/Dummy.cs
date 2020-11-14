using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Dummy : IUnit
{
    public override float health { get; set; }
    public override float power { get; set; }
    public override int movement { get; set; }
    public override AbilityType ability { get; set; }
    public override bool abilityActive { get; set; }
    public override Point point { get; set; }

    public Dummy(Point tile)
    {
        health = 0;
        power = 0;
        movement = 0;
        ability = AbilityType.Volley;
        abilityActive = false;
        point = tile;
    }

    public override void Move(Point tile)
    {}

    public override void Attack(IUnit enemy)
    {}

    public override void GetAttacked(float damage, IUnit enemy)
    {}

    public override void Recoil(float damage, IUnit enemy = null)
    {
        health += damage;
    }

    public override void Ability()
    {}
}
