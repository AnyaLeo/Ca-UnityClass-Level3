using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterReachedPoint : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool reachedEndPoint = transform.position.x <= GameManager.endPoint.position.x;
        if (reachedEndPoint)
        {
            Destroy(gameObject);
        }
    }
}
