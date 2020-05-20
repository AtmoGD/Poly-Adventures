using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData data;
    
    void Start()
    {
        data = Resources.Load("Data/Player/Player") as PlayerData;
        SendMessage("SetSpeed", data.speed);
        //SaveSystemController.SavePlayer(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public HeroType GetHeroType()
    {
        return data.heroType;
    }
}
