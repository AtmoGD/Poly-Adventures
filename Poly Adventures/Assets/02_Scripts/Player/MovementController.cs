using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class MovementController : MonoBehaviour
{
    public float speed = 5.0f;
    [Range(0.1f, 1.0f)]
    public float damping = 1.0f;


    private float actualSpeed = 0.0f;
    private Vector3 dest;
    private Rigidbody rb;
    private Animator anim;
    private GameObject cam;
    private NavMeshAgent agent;
    private bool isMoving = false;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        cam = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if (!isMoving)
            actualSpeed = actualSpeed < damping ? 0 : actualSpeed - damping;
        else
            isMoving = false;
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
            
            agent.destination = dest;
            agent.speed = speed;
            anim.SetFloat("Speed", (actualSpeed / speed));
        } else
        {
            anim.SetFloat("Speed", 0);
        }
    }
    public void Move(Vector2 direction)
    {

        dest = new Vector3(transform.position.x + direction.x, transform.position.y, transform.position.z + direction.y);
        actualSpeed = speed * direction.magnitude;
        isMoving = true;
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
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
