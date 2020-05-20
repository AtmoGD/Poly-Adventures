using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player", menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int level;
    public int health;
    public int speed;
    public int damage;
    public float attackSpeed;

}
