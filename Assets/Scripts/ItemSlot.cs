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

    public void AddItem(int itemID, string itemName, int quantity, Sprite sprite)
    {
        this.itemID = itemID;
        this.itemName = itemName;
        this.quantity = quantity;
        this.sprite = sprite;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = sprite;
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
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
    }

    public void OnRightClick()
    {
        
    }
}
