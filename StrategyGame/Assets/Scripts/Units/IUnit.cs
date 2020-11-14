using UnityEngine;
using System.Drawing;
public abstract class IUnit : MonoBehaviour
{
    public enum AbilityType { Volley, Reckless_Charge, Healing_Pulse, Stampede, Spear_Wall, Fortify};
    public abstract float health { get; set; }
    public abstract float power { get; set; }
    public abstract int movement { get; set; }
    public abstract AbilityType ability { get; set; }
    public abstract bool abilityActive { get; set; }
    public abstract Point point { get; set; }

    public abstract void Move(Point tile);
    public abstract void Attack(IUnit enemy);
    public abstract void GetAttacked(float damage, IUnit enemy);
    public abstract void Recoil(float damage, IUnit enemy = null);
    public abstract void Ability();

}
