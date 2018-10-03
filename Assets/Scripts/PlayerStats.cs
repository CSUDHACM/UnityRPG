using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "Player Data")]
public class PlayerStats : ScriptableObject
{
    public int healthCurrent;
    public int healthMax;
    public int manaCurrent;
    public int manaMax;
    public int defense;
    public int percentDefense;
    public int attack;
    public int experience;
    public int nextLevelExperience;
    public int level;
    public string characterName;
    public Weapon equippedWeapon;
    public Armor equippedArmor;
}
