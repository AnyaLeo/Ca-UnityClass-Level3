using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour
{
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        // move this object left at the specified speed (variable)
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
