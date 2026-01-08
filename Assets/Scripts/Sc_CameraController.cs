using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sc_CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;
    private void FixedUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
