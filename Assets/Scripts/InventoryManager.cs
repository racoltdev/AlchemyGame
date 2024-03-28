using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{ 

    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;

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

    public void AddItem(int itemID, string itemName, int quantity, Sprite sprite)
    {
        for (int i = 0; i< itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemID, itemName, quantity, sprite);
                return;
            }
        }

        //Debug.Log("itemID = " + itemID + "itemName = " + itemName + "quantity = " + quantity + "itemSprite = " + sprite);
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
