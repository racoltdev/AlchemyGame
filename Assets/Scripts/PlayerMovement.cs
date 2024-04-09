using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Vector3 targetPosition;
	private Vector3 lastPosition;
    private float stuckTimer = 0f;
    private float maxStuckTime = 1.5f; // Adjust as needed
	private float resetDistance = 0.5f; // Adjust as needed



    private void Start()
    {
        // Initialize target position to current position to prevent the square from moving to the middle of the screen on game start
        targetPosition = transform.position;
    }
	
	public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }

    

    private void Update()
    {
		// Check if the player has been continuously colliding with a wall in the same small range of x or y coordinates
        if (IsStuck())
        {
            // Reset the target position slightly behind the current position
            Vector3 direction = (targetPosition - transform.position).normalized;
            targetPosition = transform.position + direction * resetDistance;
        }
		
        if (Input.GetMouseButton(1)) // Right click
        {
            // Set target position to mouse position only when right-click event occurs
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f; // Ensure z-coordinate is 0 for 2D movement
        }

        MoveTowards(targetPosition);
    }

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position);
        direction.y = 0f;
        direction.Normalize();

        //Move
        transform.position += direction * moveSpeed * Time.deltaTime;

            // Check if the square is within an acceptable range of X positions to snap to the target position
            if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f)
            {
                // Snap to the target position
                transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
            }
        
    }
private bool IsStuck()
    {
        // Cast a box to check for collision with walls
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f);
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Wall"))
            {
                // Increase the stuck timer if continuously colliding with a wall in the same small range of x or y coordinates
                stuckTimer += Time.deltaTime;
                if (stuckTimer > maxStuckTime)
                {
                    return true;
                }
            }
        }
        
        // Reset the stuck timer if not colliding with any wall
        stuckTimer = 0f;
        return false;
    }

}
