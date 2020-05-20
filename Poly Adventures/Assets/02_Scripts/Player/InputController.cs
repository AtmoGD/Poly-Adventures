using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class InputController : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public FixedJoystick movementJoystic;
    public FixedJoystick attackJoystick;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                RaycastHit2D hit = Physics2D.Raycast(touch.position, Vector2.one);

                if (hit.collider != null)
                {
                    Debug.Log(hit.transform.gameObject.name);
                    Debug.Log("inside raycast");
                }
            }
        }
            
        /*
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log(hit.collider.gameObject.layer);
                    if (!(touch.position.x < 500 && touch.position.y < 500))
                    {
                        Debug.Log(hit.collider.tag);
                        if (touch.phase == TouchPhase.Moved)
                        {
                            cam.SendMessage("RotateAroundPlayer", touch.deltaPosition);
                        }
                        else
                        {
                            //TODO Handle Stuff for touch event
                        }
                    }
                }
            }
        }
        */
        HandleInput();

    }
    void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    PointerEventData pointerData = new PointerEventData(EventSystem.current);

                    pointerData.position = touch.position;

                    List<RaycastResult> results = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(pointerData, results);

                    if (results.Count > 0)
                    {
                        if (results[0].gameObject.layer != LayerMask.NameToLayer("UI"))
                        {
                            cam.SendMessage("RotateAroundPlayer", touch.deltaPosition);
                            results.Clear();
                        }
                    }
                }
            }
        }
        
        
        if (attackJoystick.Direction.magnitude > 0)
        {
            player.SendMessage("Attack", attackJoystick.Direction);
        }else
        {
            if (movementJoystic.Direction.magnitude > 0)
            {
                player.SendMessage("Move", movementJoystic.Direction);
            }
        }
    }
}
