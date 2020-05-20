using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour
{
    public HeroType heroType;
    public int level;
    public int experience;
    public int health;
    public int mana;
    public int speed;
    public int crit;
    public int critResistence;
    public int blockChance;
    public int healthRecovery;
    public int manaRecovery;

    public PlayerData(HeroType type)
    {
        heroType = type;
        level = 1;
        experience = 0;
        health = 300;
        mana = 200;
        crit = 0;
        critResistence = 0;
        blockChance = 0;
        healthRecovery = 0;
        manaRecovery = 0;
    }

}
