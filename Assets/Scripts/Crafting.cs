using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    private int[] items = new int[2];
    private int[] slots = new int[2];
    private Dictionary<int, List<int>> combinations = new Dictionary<int, List<int>>();

    public void AddItem(int itemID)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == 0)
            {
                Debug.Log("Added " + itemID + " to crafting selection");
                items[i] = itemID;
                break;
            }
        }
    }

    public void RemoveItem(int itemID)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemID)
            {
                Debug.Log("Removed " + itemID + " from crafting selection");
                items[i] = 0;
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        items[0] = 0;
        items[1] = 0;

        //Ingredients must be listed in ascending order
        List<int> ingredients;
        // Levitation = Earth + Air
        ingredients = new List<int> { 3, 4 };
        combinations.Add(9, ingredients);

        // Adhesive = Water + Earth
        ingredients = new List<int> { 1, 3 };
        combinations.Add(6, ingredients);

        // Combustion = Fire + Air
        ingredients = new List<int> { 2, 4 };
        combinations.Add(7, ingredients);

        //Sealant = Adhesive + Earth
        ingredients = new List<int> { 3, 6 };
        combinations.Add(8, ingredients);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int CraftResult() {
        Debug.Log("Crafting selection: " + items[0] + ", " + items[1]);
        bool bothItems = true;
        int craftedItem = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == 0)
            {
                Debug.Log("Craft failed");
                bothItems = false;
                break;
            }
        }
        if (bothItems)
        {
            System.Array.Sort(items);
            Debug.Log("Attempted craft: " + items[0] + ", " + items[1]);
            craftedItem = Recipe();
        }
        return craftedItem;
    }

    private int Recipe() 
    {
        foreach (KeyValuePair<int, List<int>> combo in combinations)
        {
            bool isSame = true;
            for (int i = 0; i < items.Length; i++)
            {
                
                if (combo.Value[i] != items[i])
                {
                    isSame = false;
                }
            }
            if (isSame)
            {
                Debug.Log("Matched recipe!");
                return combo.Key;
            }
        }
        Debug.Log("No recipe matched!");
        return 0;
    }
}
