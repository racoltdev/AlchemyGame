using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    private int[] items = new int[2];
    private Dictionary<int, List<int>> combinations = new Dictionary<int, List<int>>();

    public void AddItem(int itemID)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == 0)
            {
                items[i] = itemID;
            }
        }
    }

    public void RemoveItem(int itemID)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemID)
            {
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

        List<List<int>> elems = new List<List<int>>();
        elems.Add(new List<int> { 4, 3 });
        elems.Add(new List<int> { 1, 3 });

        foreach (List<int> e in elems) {
            e.Sort();
        }

        combinations.Add(9, elems[0]);
        combinations.Add(6, elems[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Craft() {
        bool bothItems = true;
        int craftedItem = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == 0)
            {
                bothItems = false;
                break;
            }
        }
        if (bothItems)
        {
            System.Array.Sort(items);
            craftedItem = getResult();
        }
        return craftedItem;
    }

    private int getResult() 
    {
        foreach (KeyValuePair<int, List<int>> combo in combinations)
        {
            bool isSame = false;
            for (int i = 0; i < items.Length; i++)
            {
                if (combo.Value[i] != items[i])
                {
                    isSame = false;
                }
            }
            if (isSame)
            {
                return combo.Key;
            }
        }
        return 0;
    }
}
