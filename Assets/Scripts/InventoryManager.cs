using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{ 

    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public int selectedItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
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

    public void SelectItem(ItemSlot item)
    {
        if (item.thisItemSelected)
        {
            selectedItems--;
            item.selectedShader.SetActive(false);
            item.thisItemSelected = false;
        }
        else if (selectedItems < 2)
        {
            selectedItems += 1;
            item.selectedShader.SetActive(true);
            item.thisItemSelected = true;
        }
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
