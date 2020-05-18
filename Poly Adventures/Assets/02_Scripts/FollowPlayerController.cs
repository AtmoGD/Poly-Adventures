using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 8, -5);
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;
    public bool rotateAroundPlayer = true;
    public float rotationSpeed = 5.0f;
    void Start()
    {
        offset = transform.position - target.position;
    }
    public void RotateAroundTarget()
    {

    }
    private void LateUpdate()
    {
        Vector3 newPos = target.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtTarget)
        {
            transform.LookAt(target);
        }
    }
}
