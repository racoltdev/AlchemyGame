using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;

    private void Start()
    {
        // Initialize target position to current position to prevent the square from moving to the middle of the screen on game start
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1)) // Right click
        {
            // Set target position to mouse position only when right-click event occurs
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f; // Ensure z-coordinate is 0 for 2D movement
        }

        MoveTowards(targetPosition);
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position);
        direction.y = 0f;
        direction.Normalize();


        
            // If not climbing, move towards the target position along the x-axis
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Check if the square is within an acceptable range of X positions to snap to the target position
            if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f)
            {
                // Snap to the target position
                transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
            }
        
    }
}
