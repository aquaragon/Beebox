using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Adjust the speed as needed
    public float changeDirectionInterval = 2.0f; // Adjust the interval for changing direction as needed
    public GameObject leftBoundary;
    public GameObject rightBoundary;
    public GameObject topBoundary;
    public GameObject bottomBoundary; // Drag and drop your "Left Boundary" GameObject here in the Inspector

    private Vector2 currentDirection;
    private float nextDirectionChangeTime;

    void Start()
    {
        // Initialize the direction and set the initial time to change direction
        currentDirection = Random.insideUnitCircle.normalized;
        nextDirectionChangeTime = Time.time + changeDirectionInterval;
    }

    void Update()
    {
        // Move the object in the current direction
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);

        // Check if it's time to change direction
        if (Time.time >= nextDirectionChangeTime)
        {
            // Generate a new random direction
            currentDirection = Random.insideUnitCircle.normalized;
            nextDirectionChangeTime = Time.time + changeDirectionInterval;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collides with the "Left Boundary"
        if (collision.gameObject == leftBoundary || collision.gameObject == rightBoundary || collision.gameObject == topBoundary || collision.gameObject == bottomBoundary)
        {
            // Reverse the direction when colliding with the boundary
            currentDirection = -currentDirection;
        }
    }
}

