using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPlatform : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Vector3 targetPosition;
    public Vector3 positionAfterFloat; 

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
}
