using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private Dictionary<string, int> items = new Dictionary<string, int>();
    public Image[] inventorySlots; // Array of inventory slot images

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem(string itemName, Sprite sprite)
    {
        Debug.Log("itemName = "+ itemName + "itemSprite = " + sprite);
    }

    public void RemoveItem(string itemName, Sprite sprite)
    {
        
    }

    public bool HasItem(string itemName, Sprite sprite)
    {
        return items.ContainsKey(itemName);
    }

    public void SetItemIcon(string itemName)
    {
        // Find an empty inventory slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].sprite == null)
            {
                // Load the icon sprite from the Resources folder
                Sprite iconSprite = Resources.Load<Sprite>("Icons/" + itemName);
                // Set the icon of the inventory slot
                inventorySlots[i].sprite = iconSprite;
                break;
            }
        }
    }
}
