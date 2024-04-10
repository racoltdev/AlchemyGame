using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCheck : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(1)||Input.GetMouseButton(0))
        {
            // Get mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            // Calculate direction vector from current position to mouse position
            Vector3 direction = mousePosition - transform.position;

            // Normalize direction vector
            direction.Normalize();



            // Flip sprite if moving left
            if (direction.x < 0)
                spriteRenderer.flipX = true;
            // Flip sprite if moving right
            else if (direction.x > 0)
                spriteRenderer.flipX = false;
        }
    }
	
}