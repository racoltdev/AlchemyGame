using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Fire,
        Water,
        Earth,
        Air,
    }

    public ItemType itemType;
    public int amount;
}
    /*[SerializeField]
    public int itemID;

    [SerializeField]
    public string itemName;

    [SerializeField]
    public int quantity;

    [SerializeField]
    public Sprite sprite;

    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(itemID, itemName, quantity, sprite);
            Destroy(gameObject);
        }
    }
}




Start is called before the first frame update
void Start()
{
    inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("Player"))
    {
        //InventoryManager inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        inventoryManager.AddItem(itemID, itemName, quantity, sprite);
        Destroy(gameObject);
    }
}

}*/
