using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    // Position of Spawner
    public Transform generatorPoint;

    // Obstacle array
    public GameObject[] obstacles;

    // Wall spawnpoints
    public Transform[] wallSpawnPoints;

    // Middle spawn area
    public MiddleSpawnArea middleSpawnArea;

    // Distance between spawned object
    public float distanceBetween;

    // Height of obstacles
    public float obstacleHeight;

    //Object pool array for obstacle object pools
    public ObjectPooler[] theObjectPools;

    //Number of spawnpoints
    public int numberOfSpawnPoints;

    //Not the same obstacle twice
    bool previous = false;
    int previousObs = 0;

    //Don't spawn the blackhole pickup while having the blackhole
    public GameObject effectGenerator;
    public GameObject blackholePickupPooler;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < generatorPoint.position.y)
        {
            SpawnObstacles();
        }
    }

    void SpawnObstacles()
    {
        int rnd = Random.Range(0, numberOfSpawnPoints);
        float newHeight = transform.position.y + obstacleHeight + distanceBetween;
        GameObject newObstacle;

        if ((rnd == 0 || rnd == 1) && !previous)
        {
            previous = true;

            //Set new height and orientation for obstacle
            int randomOrientation = Random.Range(0, 2);
            transform.position = new Vector3(wallSpawnPoints[rnd].position.x, newHeight, 15);
            if (rnd == 0 && randomOrientation == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
            }
            else if(rnd == 0 && randomOrientation == 1)
            {
                transform.rotation = Quaternion.Euler(180, 0, transform.rotation.z);
            }
            else if(rnd == 1 && randomOrientation == 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, transform.rotation.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(180, 180, transform.rotation.z);
            }
            newObstacle = theObjectPools[rnd].GetPooledObject();
        }
        else
        {
            previous = false;
            //Set new height for obstacle
            float rndX = Random.Range(-middleSpawnArea.distanceFromMiddle, middleSpawnArea.distanceFromMiddle + 1);
            transform.position = new Vector3(rndX, newHeight, 15);
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 361));
            int randomObstacle = Random.Range(2, theObjectPools.Length);
            while(randomObstacle == previousObs)
            {
                randomObstacle = Random.Range(2, theObjectPools.Length);
            }
            previousObs = randomObstacle;


            //Blackhole must be in second position in the array
            if (randomObstacle == 2)
            {
                if(effectGenerator.GetComponent<ObjectGenerator>().target == blackholePickupPooler)
                {
                    return;
                }
            }

            //Enemy must be in the third position in the array
            if (randomObstacle == 3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            newObstacle = theObjectPools[randomObstacle].GetPooledObject();
        }

        //Reuse an old object
        if(newObstacle != null)
        {
            newObstacle.transform.position = transform.position;
            newObstacle.transform.rotation = transform.rotation;
            newObstacle.SetActive(true);
        }
    }
}
