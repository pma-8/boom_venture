using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDespawner : MonoBehaviour
{
    // Update is called once per frame
    // Set the gameobject to inactive when its under the despawnpoint
    void Update()
    {
        float despawnPoint = GameObject.Find("DespawnPoint").transform.position.y;
        if (transform.position.y < despawnPoint)
        {
            gameObject.SetActive(false);
        }
    }
}
