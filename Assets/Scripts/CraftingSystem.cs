// CraftingSystem.cs
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public Inventory inventory;

    public bool CraftItem(string recipeName)
    {
        // Check if the recipe exists and player has required ingredients
        if (CheckRecipe(recipeName))
        {
            // Consume ingredients
            ConsumeIngredients(recipeName);

            // Add crafted item to inventory
            inventory.AddItem(GetCraftedItem(recipeName), 1);
            return true;
        }
        return false;
    }

    private bool CheckRecipe(string recipeName)
    {
        // Implement logic to check if the recipe exists and player has required ingredients
        return true;
    }

    private void ConsumeIngredients(string recipeName)
    {
        // Implement logic to consume ingredients from player's inventory
    }

    private string GetCraftedItem(string recipeName)
    {
        // Implement logic to determine the item crafted from the recipe
        return "CraftedItem";
    }
}
