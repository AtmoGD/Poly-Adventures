using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class DataConverter
{
    public static SerializablePlayerData ConvertFromPlayerData(PlayerData data)
    {
        SerializablePlayerData output = new SerializablePlayerData();
        output.heroType = data.heroType.ToString();
        output.level = data.level;
        output.experience = data.experience;
        output.health = data.health;
        output.mana = data.mana;
        output.speed = data.speed;
        output.crit = data.crit;
        output.critResistence = data.critResistence;
        output.blockChance = data.blockChance;
        output.healthRecovery = data.healthRecovery;
        output.manaRecovery = data.manaRecovery;
        return output;
    }
    public static PlayerData ConvertToPlayerData(SerializablePlayerData data)
    {
        PlayerData output;
        switch (data.heroType)
        {
            case "Warrior":
                output = new PlayerData(HeroType.Warrior);
                break;
            case "Hunter":
                output = new PlayerData(HeroType.Hunter);
                break;
            case "Mage":
                output = new PlayerData(HeroType.Mage);
                break;
            default:
                output = new PlayerData(HeroType.Warrior);
                Debug.Log("#00001 Cannot Load Player data");
                break;
        }
        output.level = data.level;
        output.experience = data.experience;
        output.health = data.health;
        output.mana = data.mana;
        output.speed = data.speed;
        output.crit = data.crit;
        output.critResistence = data.critResistence;
        output.blockChance = data.blockChance;
        output.healthRecovery = data.healthRecovery;
        output.manaRecovery = data.manaRecovery;

        return output;
    }
}
