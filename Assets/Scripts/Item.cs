using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField] private string itemName;
	
	[SerializeField] private Sprite sprite;
	
	[SerializeField] private float pickupRadius = 1f;
	
	private PlayerMovement playerMovement;
	
	private Inventory inventory;
	
		private bool isClicked = false;
		
	
    // Start is called before the first frame update
    void Start()
    {
		playerMovement = GameObject.Find("Marsh").GetComponent<PlayerMovement>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
		
    }

private void OnMouseDown()
    {
        isClicked = true;
    }

    // Update is called once per frame
    void Update()
    {
		
		 RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
         Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Color.red); // Visualize the raycast
		 
		 if (hit.collider == null)
            {
                // If the click is outside of the item, reset the flag
                isClicked = false;
            }
			
        if (isClicked)
        {
            // Set the item's position as the target position for the player movement
            playerMovement.SetTargetPosition(transform.position);

            // Check if the player is close enough to pick up the item
            if (Vector2.Distance(transform.position, playerMovement.transform.position) <= pickupRadius)
            {
                // Add logic to add the item to the inventory
                Debug.Log("Item collected: " + itemName);
				inventory.AddItem(itemName, sprite);

                // Reset the flag
                isClicked = false;
            }
		}
    }
}
