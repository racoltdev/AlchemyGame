using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public InventoryManager inventoryManager;

    public void ClickReaction(Item item)
    {
        Debug.Log("ClickReaction called");

        playerMovement.SetTargetPosition(item.transform.position);
        //GetItem(interact); // Pass the interact argument here

        // Add the item to the inventory
        inventoryManager.AddItem(item.itemID, item.itemName, item.quantity, item.sprite);

        // Destroy the GameObject associated with the item
        Destroy(item.gameObject);

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