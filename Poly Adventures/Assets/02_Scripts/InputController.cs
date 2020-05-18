using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
                cam.SendMessage("RotateAroundPlayer", Input.GetTouch(0).deltaPosition);
        }else if (movementJoystic.Direction.magnitude > 0)
        {
            player.SendMessage("Move", movementJoystic.Direction);
        }
    }
}
