using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroundObstacles : MonoBehaviour
{
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 4f;
    private float currentSpawnTime;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        currentSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // increment currentTime by Time.deltaTime
        currentTime += Time.deltaTime;

        // if currentTime >= currentSpawnTime
        if (currentTime >= currentSpawnTime)
        {
            // reset currentTime to 0
            currentTime = 0;
            // get random value for currentSpawnTime between minSpawnTime and maxSpawnTime
            currentSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            // call an empty function to spawn a random obstacle.
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Debug.Log("Current spawn time is " + currentSpawnTime);
    }
}
