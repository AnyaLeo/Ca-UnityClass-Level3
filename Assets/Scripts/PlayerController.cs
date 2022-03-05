using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float jumpForce = 20f;
    public float groundHeight = 2f;
    public bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpForce;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 newPos = transform.position;

        if (!isGrounded)
        {
            newPos.y = newPos.y + velocity.y * Time.fixedDeltaTime;
            newPos.y = newPos.y - gravity * Time.fixedDeltaTime;

            bool playerReachedGround = newPos.y <= groundHeight;
            if (playerReachedGround)
            {
                newPos.y = groundHeight;
                isGrounded = true;
            }
        }

        transform.position = newPos;
    }
}
