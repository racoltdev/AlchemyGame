using UnityEngine;

public class EnemyMovement : MonoBehaviour
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
        targetPosition = GetPlayerPos();

        MoveTowards(targetPosition);
    }

    private Vector3 GetPlayerPos()
    {
        var player = GameObject.Find("Square");
        if (player)
        {
            return player.transform.position;
        }
        else
        {
            return transform.position;
        }
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
