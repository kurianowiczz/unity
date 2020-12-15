using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = .125f;
    [SerializeField] private float distance = -19;
    [SerializeField] private float distanceY;
    void Update()
    {
        var offset = target.position + distance * target.forward;
        offset.y = distanceY;
        var smoothPosition = Vector3.Lerp(transform.position, offset, smoothSpeed);
        transform.position = smoothPosition;
        transform.rotation = Quaternion.LookRotation(target.forward);
    }
}
