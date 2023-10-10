
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;
    public float cameraSpeed = 0.1f;

    void Start()
    {
        transform.position = player.position + cameraOffset;
    }

    void FixedUpdate()
    {
        Vector3 finalPosition = player.position + cameraOffset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);
        transform.position = lerpPosition;
    }
}
*/
using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.y -1); 
    }
} 