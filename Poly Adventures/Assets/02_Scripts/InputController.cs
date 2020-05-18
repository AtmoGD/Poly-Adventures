using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject player;
    public FixedJoystick movementJoystic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movementJoystic.Direction.magnitude > 0)
        {
            player.SendMessage("Move", movementJoystic.Direction);
        }
    }
}
