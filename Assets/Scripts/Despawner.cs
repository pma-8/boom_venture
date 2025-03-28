using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public GameObject despawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < despawnPoint.transform.position.y)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
