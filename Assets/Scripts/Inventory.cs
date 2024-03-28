using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Fire, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Water, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Earth, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
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
    }*/
