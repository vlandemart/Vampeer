﻿
using UnityEngine;

public class CameraFollowingTarget : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float cameraDistance = 40f;


    void LateUpdate()
    {
        Vector3 desiredPosition = transform.position = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}
