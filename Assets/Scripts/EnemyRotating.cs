using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotating : MonoBehaviour
{
    int rotate;
    public int rotateSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x + rotate, -90, transform.rotation.z);
        rotate += rotateSpeed;
    }
}
