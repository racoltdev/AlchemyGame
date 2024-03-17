using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    // Highlight color
    public Color highlightColor = Color.magenta;

    // Original color
    private Color originalColor;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Store the original color
        originalColor = spriteRenderer.color;
    }

    private void OnMouseEnter()
    {
        // Change the color to the highlight color when the mouse enters
        spriteRenderer.color = highlightColor;
    }

    private void OnMouseExit()
    {
        // Restore the original color when the mouse exits
        spriteRenderer.color = originalColor;
    }
}
