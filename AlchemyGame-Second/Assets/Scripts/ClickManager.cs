using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public InventoryManager inventoryManager;

    /*public void ClickReaction(InteractData interact)
    {
        playerMovement.SetTargetPosition(interact.goToPoint.position);
        GetItem(interact); // Pass the interact argument here
    }*/

    void Update()
    {
        if (Input.GetButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    GetItem(item);
                }
                else
                {
                    playerMovement.SetTargetPosition(hit.point);
                }
            }
        }
    }


    private void GetItem(Item item)
    {
        if (IsValidCraftingItem(item.itemID))
        {

            inventoryManager.AddItem(item.itemName, item.quantity, item.sprite);
            Debug.Log("Success! " + item.itemName + "added to inventory.");
        }
        else
        {
            Debug.Log("Failure: Incorrect itemID!");
        }
        Destroy(item.gameObject);
    }

    private bool IsValidCraftingItem(int itemID)
    {
        //add crafting code
        
    }
       
        
        /*(InteractData interact)
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
        }*/
    }
}
