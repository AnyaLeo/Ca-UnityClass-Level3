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
    public float jumpGroundThreshold = 0.2f;
    public float maxAcceleration = 10f;
    public float currentAcceleration = 10f;
    public float maxHorizontalVelocity = 100f;
    public float distanceCovered = 0f;

    Vector2 rayOrigin;
    Vector2 rayDirection;
    public float rayDistance = 2.5f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);

        bool playerCanJump = isGrounded || groundDistance <= jumpGroundThreshold;
        if (playerCanJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;

                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 newPos = transform.position;

        if (!isGrounded)
        {
            newPos.y = newPos.y + velocity.y * Time.fixedDeltaTime;
            //velocity.y = velocity.y - gravity * Time.fixedDeltaTime;

            /*bool playerReachedGround = newPos.y <= groundHeight;
            if (playerReachedGround)
            {
                newPos.y = groundHeight;
                isGrounded = true;
            }*/
        }

        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxHorizontalVelocity;
            currentAcceleration = maxAcceleration * (1 - velocityRatio);

            velocity.x += currentAcceleration * Time.fixedDeltaTime;
            bool exceededMaxVelocity = velocity.x >= maxHorizontalVelocity;
            if (exceededMaxVelocity)
            {
                velocity.x = maxHorizontalVelocity;
            }
        }

        rayOrigin = new Vector2(newPos.x, newPos.y);
        rayDirection = Vector2.down;
        RaycastHit2D objectHit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, LayerMask.GetMask("Ground"));
        bool didRayHitSomething = objectHit.collider != null;

        if (didRayHitSomething)
        {
            isGrounded = true;
        } 
        else
        {
            isGrounded = false;
        }

        transform.position = newPos;
        distanceCovered += velocity.x * Time.fixedDeltaTime;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.green);
    }
}
