using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public string itemName;
    private Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
    }

    private void OnMouseDown()
{
    Debug.Log("Clicked on: " + itemName); // Check if the method is being called
    inventory.AddItem(itemName, 1);
    inventory.SetItemIcon(itemName);
}

}
