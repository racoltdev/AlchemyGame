using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    private string[] items = new string[2];
    private Dictionary<string, List<string>> combinations = new Dictionary<string, List<string>>();

    public void AddItem(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (string.IsNullOrEmpty(items[i]))
            {
                items[i] = itemName;
            }
        }
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (string.Equals(items[i], itemName))
            {
                items[i] = "";
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        List<List<string>> elems = new List<List<string>>();
        elems.Add(new List<string> { "Air", "Earth" });
        elems.Add(new List<string> { "Earth", "Water" });

        foreach (List<string> e in elems) {
            e.Sort();
        }

        combinations.Add("Levitation", elems[0]);
        combinations.Add("Adhesive", elems[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string Craft() {
        bool bothItems = true;
        string craftedItem = "";
        for (int i = 0; i < items.Length; i++)
        {
            if (string.IsNullOrEmpty(items[i]))
            {
                bothItems = false;
                break;
            }
        }
        if (bothItems)
        {
            System.Array.Sort(items);
            getResult();
        }
        return craftedItem;
    }

    private string getResult() 
    {
        foreach (KeyValuePair<string, List<string>> combo in combinations)
        {
            bool isSame = false;
            for (int i = 0; i < items.Length; i++)
            {
                if (!string.Equals(combo.Value[i], items[i]))
                {
                    isSame = false;
                }
            }
            if (isSame)
            {
                return combo.Key;
            }
        }
        return "";
    }
}
