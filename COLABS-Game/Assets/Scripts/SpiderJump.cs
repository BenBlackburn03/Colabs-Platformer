using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementWithJump : MonoBehaviour
{
    public float minX = -5f;
    public float maxX = 5f;
    public float groundY = 2f; // The Y position to stay on
    public float jumpHeight = 2f;
    public float jumpFrequency = 1f;
    public float moveSpeed = 5f;

    private Vector2 targetPosition;
    private bool isGrounded;
    private float jumpTimer;

    void Start()
    {
        // Set an initial random target position
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Move towards the target position on the X-axis
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

        // Check if the enemy is grounded
        if (isGrounded)
        {
            // Stay on the specified Y position
            transform.position = new Vector2(transform.position.x, groundY);
        }
        else
        {
            // Periodically jump on the Y-axis using Mathf.Sin
            Jump();
        }

        // Check if the enemy has reached the target position
        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Set a new random target position and enter the grounded state
            SetRandomTargetPosition();
            isGrounded = true;
        }
    }

    void SetRandomTargetPosition()
    {
        // Calculate random X position within the specified range
        float targetX = Random.Range(minX, maxX);

        // Update the target position
        targetPosition = new Vector2(targetX, transform.position.y);

        // Reset the jump timer
        jumpTimer = 0f;

        // Exit the grounded state
        isGrounded = false;
    }

    void Jump()
    {
        // Increment the jump timer
        jumpTimer += Time.deltaTime;

        // Calculate the jump offset using Mathf.Sin for a periodic jump
        float jumpOffset = jumpHeight * Mathf.Sin(jumpFrequency * jumpTimer);

        // Update the Y position with the jump offset
        transform.position = new Vector2(transform.position.x, groundY + jumpOffset);

        // Check if the jump is complete
        if (jumpOffset <= 0f)
        {
            // Enter the grounded state
            isGrounded = true;
        }
       
    }
}
