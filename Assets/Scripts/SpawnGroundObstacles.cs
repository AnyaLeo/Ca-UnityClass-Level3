using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpawnGroundObstacles : MonoBehaviour
{
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 4f;
    private float currentSpawnTime;
    private float currentTime;

    private RandomTerrainGenerator terrainGen;

    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
        currentSpawnTime = 0f;

        terrainGen = FindObjectOfType<RandomTerrainGenerator>();
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

        // Get SpriteShapeController component from the current last terrain
        SpriteShapeController lastTerrainSprite = terrainGen.lastTerrain.GetComponent<SpriteShapeController>();

        // Get a random point from this lastTerrainSprite
        // and get its position for our new obstacle

        // lastTerrainSprite.spline.GetPointCount() 
        // lastTerrainSprite.spline.GetPosition(int index)

        // YOUR TASK IS:
        // 1) Get a random position from the last terrain

        // get the index for a specific point
        int pointsTotal = lastTerrainSprite.spline.GetPointCount();
        int randomPoint = Random.Range(0, pointsTotal);

        // get the position for that specific point
        Vector3 randomPointPos = lastTerrainSprite.spline.GetPosition(randomPoint);

        // 2) Spawn the cactus at that position
        GameObject newObstacle = Instantiate(obstacle, randomPointPos, Quaternion.identity);
    }
}
