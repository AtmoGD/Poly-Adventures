using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public WeaponType weaponType;
    public GameObject attackPrefab;
    public float attackSpeed;
    public float damage;
}
