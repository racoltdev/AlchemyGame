using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public void ClickReaction(Item item, PlayerMovement playerMovement)
    {
        Debug.Log("ClickReaction called");

        playerMovement.SetTargetPosition(item.transform.position);

        // Call the CollectItem method of the clicked item
        item.CollectItem();

        // Debug to ensure that the ClickReaction method is being called
        Debug.Log("Item clicked: " + item.gameObject.name);
    }
}

/*private void GetItem(InteractData interact)
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