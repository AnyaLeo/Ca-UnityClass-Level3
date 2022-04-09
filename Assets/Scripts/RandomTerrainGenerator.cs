using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTerrainGenerator : MonoBehaviour
{
    public GameObject[] terrainPieces;
    public List<GameObject> createdTerrains;
    public float speed = 2f;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < createdTerrains.Count; i++)
        {
            createdTerrains[i].transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
