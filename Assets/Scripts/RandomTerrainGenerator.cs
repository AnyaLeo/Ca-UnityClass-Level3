using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


public class RandomTerrainGenerator : MonoBehaviour
{
    public GameObject[] terrainPieces;
    public List<GameObject> createdTerrains;
    public float speed = 2f;

    private Camera cam;

    GameObject lastTerrain;
    float lastTerrainLength;

    public bool terrainVisible;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        SpriteShapeRenderer sprite = createdTerrains[createdTerrains.Count - 1].GetComponent<SpriteShapeRenderer>();
        lastTerrainLength = sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < createdTerrains.Count; i++)
        {
            createdTerrains[i].transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //terrainVisible = IsLastTerrainVisible();
        if (IsLastTerrainVisible())
        {
            AddNewTerrain();
        }
    }

    public bool IsLastTerrainVisible()
    {
        bool result = false;

        // Always make sure we have a reference to the last terrain piece
        lastTerrain = createdTerrains[createdTerrains.Count - 1];

        // Find the leftmost point of the terrain piece
        float leftmostXPoint = lastTerrain.transform.position.x - (lastTerrainLength / 2);
        float leftmostYPoint = lastTerrain.transform.position.y;

        Vector3 leftmostPoint = new Vector3(leftmostXPoint, leftmostYPoint, 0f);

        // Calculate if last terrain entered our viewport
        Vector3 viewPoint = cam.WorldToViewportPoint(leftmostPoint);
        result = viewPoint.x >= 0f && viewPoint.x <= 1f;

        return result;
    }

    public void AddNewTerrain()
    {
        int randomIndex = Random.Range(0, terrainPieces.Length);
        GameObject newTerrain = Instantiate(terrainPieces[randomIndex]);

        // FIND POSITION FOR NEW TERRAIN
        // 1) find rightmost point for current last terrain
        float rightmostXPoint = lastTerrain.transform.position.x + (lastTerrainLength / 2);
        float rightmostYPoint = lastTerrain.transform.position.y;

        // 2) calculate new terrain length 
        SpriteShapeRenderer sprite = newTerrain.GetComponent<SpriteShapeRenderer>();
        float newTerrainLength = sprite.bounds.size.x;

        // 3) calculate new position based on rightmost point and terrain length
        float newTerrainX = rightmostXPoint + (newTerrainLength / 2) - 0.1f;
        float newTerrainY = rightmostYPoint;
        Vector3 newTerrainPos = new Vector3(newTerrainX, newTerrainY);

        // 4) set new position for terrain
        newTerrain.transform.position = newTerrainPos;

        // CLEANUP
        // Update last terrain variables
        createdTerrains.Add(newTerrain);
        lastTerrainLength = newTerrainLength;
        lastTerrain = newTerrain;
    }
}
