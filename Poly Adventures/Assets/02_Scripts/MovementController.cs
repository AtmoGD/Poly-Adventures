using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class MovementController : MonoBehaviour
{
    public float speed = 5.0f;
    private float actualSpeed = 0.0f;
    [Range(0.1f, 1.0f)]
    public float damping = 1.0f;

    private Rigidbody rb;
    private Animator anim;
    private GameObject cam;
    private bool isMoving = false;
    public Text text;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        cam = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if (!isMoving)
            actualSpeed = actualSpeed < damping ? 0 : actualSpeed - damping;
        else
            isMoving = false;
    }
    public void Move(Vector2 movement)
    {
        actualSpeed = speed * movement.magnitude;
        isMoving = true;
        Rotate(movement);
    }
    public void Rotate(Vector2 direction)
    {
        if (rb)
        {
            float angle = -(float)Math.Atan2(direction.y, direction.x);
            angle *= Mathf.Rad2Deg;
            angle += cam.transform.eulerAngles.y;
            rb.rotation = Quaternion.Euler(0, angle + 90, 0);
            rb.rotation.SetLookRotation(direction, cam.transform.up);
        }
    }
    void FixedUpdate()
    {
        if (!rb)
        {
            
            Debug.LogError("Couldn't find a rigidbody");
            return;
        }

        if (actualSpeed > 0)
        {
            rb.MovePosition(rb.position + (transform.forward * Time.fixedDeltaTime * actualSpeed));
            anim.SetFloat("Speed", (actualSpeed / speed));
        } else
        {
            anim.SetFloat("Speed", 0);
        }
    }
}
