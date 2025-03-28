using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    int rotate;
    public int rotateSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotate);
        rotate += rotateSpeed;
    }
}
