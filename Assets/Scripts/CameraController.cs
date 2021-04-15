using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private Vector3 offset;
    Vector3 offsetPos;
    Vector3 stopCamera;
    private void Start()
    {
        stopCamera = new Vector3(0, 6, 20);
    }
    private void LateUpdate()
    {
        offsetPos = ball.position + offset;
        if (offsetPos.z < stopCamera.z)
        {
            transform.position = offsetPos;
        }
        else
            transform.position = stopCamera;
        transform.LookAt(ball);
    }
    
}
