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
    public bool rotateAroundTarget = true;
    public float rotationSpeed = 2.0f;
    void Start()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
    public void RotateAroundPlayer(Vector2 deltaPosition)
    {
        if (Mathf.Abs(deltaPosition.x) > Mathf.Abs(deltaPosition.y))
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(deltaPosition.x < 0 ? -rotationSpeed : rotationSpeed, Vector3.up);
            offset = camTurnAngle * offset;
        }else
        {
            offset.y += deltaPosition.y * Time.deltaTime * 0.5f;
            offset.y = offset.y < 0.5f ? 0.5f : offset.y > 12 ? 12 : offset.y;
        }

    }
    private void LateUpdate()
    {
        Vector3 newPos = target.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtTarget || rotateAroundTarget)
        {
            transform.LookAt(target);
        }
    }
}
