using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour
{
    private GameObject primaryHand;
    private GameObject secondaryHand;

    // Start is called before the first frame update
    void Start()
    {
        HeroType type = this.gameObject.GetComponent<PlayerController>().GetHeroType();
        GetHands(type);
    }

    private void GetHands(HeroType type)
    {
        GameObject right = new GameObject();
        GameObject left = new GameObject();

        foreach (Transform obj in this.gameObject.GetComponentsInChildren<Transform>())
        {
            if (obj.name == "weaponShield_r")
            {
                right = obj.gameObject;
            }
            if (obj.name == "weaponShield_l")
            {
                left = obj.gameObject;
            }
        }

        primaryHand = type == HeroType.Hunter ? left : right;
        secondaryHand = type == HeroType.Hunter ? right : left;
    }
}
