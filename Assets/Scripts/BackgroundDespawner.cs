using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDespawner : MonoBehaviour
{
    // Update is called once per frame
    // Set the gameobject to inactive when its under the despawnpoint
    void Update()
    {
        float despawnPoint = GameObject.Find("BackgroundDespawnPoint").transform.position.y;
        if (transform.position.y + 20 < despawnPoint)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 80 , transform.position.z);
        }
    }
}
