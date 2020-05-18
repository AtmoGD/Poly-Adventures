using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public FixedJoystick movementJoystic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && (movementJoystic.Direction.magnitude == 0))
        {
            Debug.Log(Input.GetTouch(0).deltaPosition.magnitude);
            cam.SendMessage("RotateAroundTargetHorizontal", Input.GetTouch(0).deltaPosition);
        }
        if (movementJoystic.Direction.magnitude > 0)
        {
            player.SendMessage("Move", movementJoystic.Direction);
        }
    }
}
