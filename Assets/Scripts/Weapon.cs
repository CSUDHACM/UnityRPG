using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string WeaponName;
    public int damage;
    public double damageVarience;   //should be no greater than 1, else negative damage is possible on attacksx
    public int critDeviance;
    public int critMultiplier;

    public int GetDamage()
    {
        return damage;
    }

    public double GetDamageVarience()
    {
        return damageVarience;
    }

    public int GetCritDeviance()
    {
        return critDeviance;
    }

    public int GetCritMultiplier()
    {
        return critMultiplier;
    }

}
