using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = 72f;
    public float maxY = 80f;
    public float moveSpeed = 5f;

    private Vector2 targetPosition;

    void Start()
    {
        // Set an initial random target position
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Move towards the target position
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

        // Check if the enemy has reached the target position
        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Set a new random target position
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // Calculate random X and Y positions within the specified ranges
        float targetX = Random.Range(minX, maxX);
        float targetY = Random.Range(minY, maxY);

        // Update the target position
        targetPosition = new Vector2(targetX, targetY);
    }
}