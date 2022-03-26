using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float speed = 5f;
    public float bgLength;
    public float bgStartPos;
    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        bgStartPos = transform.position.x;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        bgLength = sprite.bounds.size.x;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        bool shouldLoopBackground = transform.position.x <= (bgStartPos - bgLength);
        if (shouldLoopBackground)
        {
            transform.position = startPosition;
        }
    }
}
