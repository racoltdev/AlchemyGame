using UnityEngine;

public class GoToPointTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ClickManager clickManager = FindObjectOfType<ClickManager>();
            if (clickManager != null)
            {
                clickManager.PlayerEnteredTrigger();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ClickManager clickManager = FindObjectOfType<ClickManager>();
            if (clickManager != null)
            {
                clickManager.PlayerExitedTrigger();
            }
        }
    }
}
