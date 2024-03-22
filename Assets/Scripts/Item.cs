using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int itemID;
    public string itemName;
    public int quantity;
    public Sprite sprite;


    /*private InventoryManager inventoryManager;


     Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            InventoryManager inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
            inventoryManager.AddItem(itemID, itemName, quantity, sprite);
            Destroy(gameObject);
        }
    }*/

}
