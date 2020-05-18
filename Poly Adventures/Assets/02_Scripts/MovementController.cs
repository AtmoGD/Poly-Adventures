using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    public float speed = 5.0f;
    private float actualSpeed = 0.0f;
    [Range(0.1f, 1.0f)]
    public float damping = 1.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Move(Vector2 movement)
    {
        actualSpeed = speed;
        Rotate(movement);
    }
    public void Rotate(Vector2 direction)
    {
        if (rb)
        {
            float angle = -(float)Math.Atan2(direction.y, direction.x);
            rb.rotation = Quaternion.Euler(0, (Mathf.Rad2Deg * angle) + 90, 0);
        }
    }
    private void FixedUpdate()
    {
        if (!rb)
        {
            Debug.LogError("Couldn't find a rigidbody");
            return;
        }

        if (actualSpeed > 0)
        {
            rb.MovePosition(rb.position + (transform.forward * Time.deltaTime * speed));
            actualSpeed -= damping;
        }
    }
}
