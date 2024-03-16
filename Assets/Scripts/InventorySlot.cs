using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image iconImage;
    public string itemName;

    // Add reference to the Inventory instance
    private Inventory inventory;

    private void Start()
    {
        // Get the Inventory instance
        inventory = Inventory.instance;
    }

    public void AddItemToInventory()
    {
        // Add the item to the inventory
        inventory.AddItem(itemName, 1);
        // Update the icon to reflect the newly added item
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        // Update the icon image to display the item's icon
        if (inventory.HasItem(itemName, 1))
        {
            // Load the icon sprite from resources folder (assuming sprites are stored there)
            Sprite iconSprite = Resources.Load<Sprite>("Icons/" + itemName);
            iconImage.sprite = iconSprite;
        }
        else
        {
            // If the item is not in the inventory, clear the icon
            iconImage.sprite = null;
        }
    }
}
