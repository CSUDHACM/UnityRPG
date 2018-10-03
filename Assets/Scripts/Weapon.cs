using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string weaponName;
    public int damage;
    public int unignorableDamage;   //TODO: enemy monsters should get this value in their receiveAttack method
    public double damageVarience;   //should be no greater than 1, else negative damage is possible on attacksx
    public int critDeviance;        //if <= -4, unable to crit
    public int critMultiplier;     //1 = normal damage, 2 = double damage, 3 = triple damage, etc

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
