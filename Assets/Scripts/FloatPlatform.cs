using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPlatform : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Vector3 targetPosition;
    public Vector3 positionAfterFloat;

    private int waterItemCount = 0;

    public GameObject goalObject;
    private bool isGoalFloating = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        var floatHeightObject = GameObject.Find("Water 1 Height");
        positionAfterFloat = floatHeightObject.transform.position;
        WaterPlaced();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards(targetPosition);

        if (isGoalFloating)
        {
            goalObject.transform.position += targetPosition - transform.position;
        }
    }

    void WaterPlaced()
    {
        targetPosition = positionAfterFloat;
    }

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position);
        direction.x = 0f;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            waterItemCount++;

            if (waterItemCount == 1)
            {
                targetPosition.y += 1.0f;
            }
            else if (waterItemCount == 3)
            {
                targetPosition.y += 2.0f;

                if (goalObject != null)
                {
                    isGoalFloating = true;
                }
            }
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Water"))
        {
            if (waterItemCount == 0)
            {
                targetPosition.y = positionAfterFloat.y;

                isGoalFloating = false;
            }
        }
    }
}
