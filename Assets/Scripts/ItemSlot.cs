using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //------ITEM DATA------//

    public int itemID;
    public string itemName;
    public int quantity;
    public Sprite sprite;
    public bool isFull;

    [SerializeField]
    private int maxNumberOfItems;

    //------ITEM SLOT------//

    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }  

    public int AddItem(int itemID, string itemName, int quantity, Sprite sprite)
    {
        // Check if slot is full

        if (isFull)
            return quantity;

        this.itemID = itemID;
        this.itemName = itemName;

        this.sprite = sprite;
        itemImage.sprite = sprite;

        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            // Return Leftovers

            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        // update quantity text

        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;




    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }

    }

    public void OnLeftClick()
    {
        inventoryManager.SelectItem(this);
    }

    public void OnRightClick()
    {
        
    }
}
