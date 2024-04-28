using UnityEngine;

public class HorizontalFloatPlatform : MonoBehaviour
{
    public float moveSpeed = 1f;
    private bool isMoving = false;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveTowards(targetPosition);
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0f;
        transform.position += direction * moveSpeed * Time.deltaTime;

 
        if (transform.position.x <= targetPosition.x)
        {
            isMoving = false;
            transform.position = targetPosition;
        }
    }

    // trigger movement by wind element
    public void MoveByWind(Vector3 destination)
    {
       
        if (destination.x < transform.position.x)
        {
            targetPosition = destination;
            isMoving = true;
        }
    }
}
