using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour

{
    public int itemID;
    public string itemName;
    public int quantity;
    public Sprite sprite;
    //public Transform goToPoint;

    private InventoryManager inventoryManager;
    

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    void OnItemClicked()
    {
        ClickManager clickManager = FindObjectOfType<ClickManager>();
        if (clickManager != null)
        {
            clickManager.ClickReaction(this.GetComponent<Item>());
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemID, itemName, quantity, sprite);
            if (leftOverItems <= 0)
                Destroy(gameObject);
            else
                quantity = leftOverItems;
        }
    }*/

}