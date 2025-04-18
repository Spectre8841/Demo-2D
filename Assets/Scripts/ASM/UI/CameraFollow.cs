using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3 (0, 0, -10);
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothPosition;
        }
    }
}
