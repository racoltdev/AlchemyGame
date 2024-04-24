using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{ 

    public GameObject InventoryMenu;
    public ItemSlot[] itemSlot;
    public int selectedItems;

    private Crafting crafter;

    // Start is called before the first frame update
    void Start()
    {
        crafter = GameObject.Find("InventoryCanvas").GetComponent<Crafting>();
    }

    // Update is called once per frame
    void Update()
    {
            InventoryMenu.SetActive(true);
          
    }
   
    public int AddItem(int itemID, string itemName, int quantity, Sprite sprite)
    {
        for (int i = 0; i< itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemID, itemName, quantity, sprite);
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemID, itemName, leftOverItems, sprite);
                return leftOverItems;
            }
        }
        return quantity;

        //Debug.Log("itemID = " + itemID + "itemName = " + itemName + "quantity = " + quantity + "itemSprite = " + sprite);
    }

    public void RemoveItem(int slotID)
    {
        int itemID = itemSlot[slotID].itemID;
        itemSlot[slotID].RemoveItem();
    }

    public void SelectItem(ItemSlot item)
    {
        int itemID = item.itemID;
        if (item.thisItemSelected)
        {
            selectedItems--;
            item.selectedShader.SetActive(false);
            item.thisItemSelected = false;
            crafter.RemoveItem(itemID);

        }
        else if (selectedItems < 2 && itemID != 0)
        {
            selectedItems += 1;
            item.selectedShader.SetActive(true);
            item.thisItemSelected = true;
            crafter.AddItem(itemID);
            if (selectedItems == 2)
            {
                // This is where logic for enabling "Craft" button would go 

            }
        }
    }

    public void Craft()
    {
        if (selectedItems != 2) { return; }
        int craftedItemID = crafter.CraftResult();
        if (craftedItemID == 0) { return; }
        Debug.Log("Crafted item: " + craftedItemID);

        // Replace inventory items with crafted item
        // I should just track what items are selected, but I don't want to
        int craftedItemSlot = -1;
        for (int i = 0; i < itemSlot.Length; i++)
        {
            ItemSlot item = itemSlot[i];
            if (item.thisItemSelected)
            {
                if (craftedItemSlot == -1) { craftedItemSlot = i; }
                SelectItem(item);
                RemoveItem(i);
            }
        }
        int d = AddItem(craftedItemID, "filler", 1, null);
    }


    public void DeselectAllSlots()
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

}
