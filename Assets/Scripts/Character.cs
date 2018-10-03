using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public PlayerStats playerStats;


    //public int playerStats.healthCurrent;
    //public int playerStats.healthMax;
    //public int playerStats.manaCurrent;
    //public int playerStats.manaMax;
    //public int playerStats.defense;
    //public int playerStats.attack;
    //public int experience;
    //public int playerStats.nextLevelExperience;
    //public int level;
    //public string playerStats.characterName;
    //public Weapon playerStats.equippedWeapon;
    //public Armor playerStats.equippedArmor;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetName(string name)
    {
        playerStats.characterName = name;
    }

    public void HealthUpdate(int delta)    //change current health
    {
        playerStats.healthCurrent += delta;
        if (playerStats.healthCurrent > playerStats.healthMax)
            playerStats.healthCurrent = playerStats.healthMax;
        else if (playerStats.healthCurrent <= 0)
        {
            //TODO: DIE
        }
    }

    public void ManaUpdate(int delta)      //change current mana
    {
        playerStats.manaCurrent += delta;
        if (playerStats.manaCurrent > playerStats.manaMax)
            playerStats.manaCurrent = playerStats.manaMax;
    }

    public void MaxHealthUpdate(int delta)  //change health max
    {
        playerStats.healthCurrent += delta;
        playerStats.healthMax += delta;
    }

    public void MaxManaUpdate(int delta)   //change mana max
    {
        playerStats.manaCurrent += delta;
        playerStats.manaMax += delta;
    }

    public void AttackUpdate(int delta)
    {
        playerStats.attack += delta;
    }

    public void DefenseUpdate(int delta)
    {
        playerStats.defense += delta;
    }

    public void Experience(int gained)      //gain xp from quest/monster/whatever
    {
        playerStats.experience += gained;
        while (playerStats.experience >= playerStats.nextLevelExperience)
        {
            playerStats.experience -= playerStats.nextLevelExperience;
            LevelUp();
        }
    }

    public void LevelUp()   //do a levelup
    {
        playerStats.level++;
        playerStats.nextLevelExperience = (int)(playerStats.nextLevelExperience * 1.1);      //placeholder experience needed gain
        MaxHealthUpdate(10 * playerStats.level);
        playerStats.healthCurrent = playerStats.healthMax;
        playerStats.manaCurrent = playerStats.manaMax;
    }

    public void MagicExperience(int gained)     //big spells should give more xp
    {
        playerStats.magicExperience += gained;
        while (playerStats.magicExperience >= playerStats.nextMagicLevelExperience)
        {
            playerStats.magicExperience -= playerStats.nextMagicLevelExperience;
            MagicLevelUp();
        }
    }

    public void MagicLevelUp()
    {
        playerStats.magicLevel++;
        playerStats.nextMagicLevelExperience = (int)(playerStats.nextMagicLevelExperience * 1.1);       //placeholder expereince needed gain
        MaxManaUpdate(10 * playerStats.magicLevel);
        ManaUpdate(10 * playerStats.magicLevel);
    }

    public int AttackSomething()    //if crit deviance <= -4, it is impossible to crit (without something else)
    {
        int min = (int)  ((playerStats.equippedWeapon.GetDamage() + playerStats.attack) * (1 - playerStats.equippedWeapon.GetDamageVarience()));  //no +1 because min is inclusive
        int max = (int)  ((playerStats.equippedWeapon.GetDamage() + playerStats.attack) * (1 + playerStats.equippedWeapon.GetDamageVarience())) + 1;  //+1 because max is exclusive
        if ( (Random.Range(1,100) + playerStats.equippedWeapon.GetCritDeviance()) >= 97)
        {
            return Random.Range(min, max) * playerStats.equippedWeapon.GetCritMultiplier();
        }
        return Random.Range(min, max);
    }

    public int ReceiveAttack(int damageReceived, int unignorableDamage)
    {
        int damageTaken = (int) ((damageReceived - playerStats.defense - playerStats.equippedArmor.GetArmorDefense()) *
                                 (1 - playerStats.equippedArmor.GetPercentDefense() - playerStats.percentDefense)) + unignorableDamage;
        HealthUpdate(damageTaken);
        return damageTaken;
    }
}