/*using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public void ClickReaction(InteractData interact)
    {
        playerMovement.SetTargetPosition(interact.goToPoint.position);
        GetItem(interact); // Pass the interact argument here
    }

    private void GetItem(InteractData interact)
    {
        // Check if player reached the goToPoint position
        if (Vector2.Distance(playerMovement.transform.position, interact.goToPoint.position) < 1.5f)
        {
            // Check if the itemID is 2
            if (interact.itemID == 2)
            {
                Debug.Log("Success!");
            }
            else
            {
                Debug.Log("Failure: Incorrect itemID!");
            }
        }
    }
}*/

using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public void ClickReaction(Item item)
    {
        // Example logic based on item properties
        if (item.itemID == 2)
        {
            Debug.Log("Success!");
        }
        else
        {
            Debug.Log("Failure: Incorrect itemID!");
        }
    }
}