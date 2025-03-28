using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Object that the camera follows
    public Transform target;

    // How smooth the camera should follow
    public float smoothSpeed;

    private Vector3 currentVelocity;

    // Update is called once after frame
    void Update()
    {       //When our target is higher than the middle of the screen
        if (target.position.y > transform.position.y)
        {
            // The new camera position
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            // Lerp isn't good for smooth
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        }
    }
}
