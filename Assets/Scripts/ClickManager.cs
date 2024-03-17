using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private bool playerInTrigger = false;

    public void ClickReaction(InteractData interact)
    {
        playerMovement.SetTargetPosition(interact.goToPoint.position);
        GetItem(interact);
    }
    
    private void GetItem(InteractData interact)
    {
        if (playerInTrigger)
        {
            Debug.Log("Player is in trigger zone");
            // Check the distance between player and goToPoint
            if (Vector2.Distance(playerMovement.transform.position, interact.goToPoint.position) < 0.1f)
            {
                Debug.Log("Item collected: " + interact.itemID);
                // Add logic to handle item collection based on interact.itemID
            }
            else
            {
                Debug.Log("Failed to collect item: Player is not at goToPoint");
            }
        }
        else
        {
            Debug.Log("Player is not in trigger zone");
        }
    }

    public void PlayerEnteredTrigger()
    {
        playerInTrigger = true;
    }

    public void PlayerExitedTrigger()
    {
        playerInTrigger = false;
    }
}
