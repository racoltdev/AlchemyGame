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

    public string getNameFromID(int itemID)
    {
        switch (itemID)
        {
            case 1:
                return "Water";
            case 2:
                return "Fire";
            case 3:
                return "Earth";
            case 4:
                return "Air";
            case 5:
                return "Metal";
            case 6:
                return "Adhesive";
            case 7:
                return "Combustion";
            case 8:
                return "Sealant";
            case 9:
                return "Levitation";
            default:
                return "";
        }
    }

    public Sprite getItemSprite(int itemID, string itemName)
    {
        string path = "Icons/" + itemName + " Sprite";
        Debug.Log("Crafted item icon: " + path);
        Sprite sprite = Resources.Load<Sprite>(path);
        //Texture2D tex = Resources.Load<Texture2D>(path);
        //Rect rec = new Rect(0, 0, tex.width, tex.height);
        //Sprite sprite = Sprite.Create(tex, rec, new Vector2(0, 0), 1);
        
        return sprite;
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
        string craftedItemName = getNameFromID(craftedItemID);
        if (craftedItemName.Equals(""))
        {
            Debug.Log("Invalid item crafted");
            return;
        }
        Sprite sprite = getItemSprite(craftedItemID, craftedItemName);
        if (sprite == null)
        {
            Debug.Log("Null sprite generated");
        }
        int d = AddItem(craftedItemID, craftedItemName, 1, sprite);
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
