using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int health = 1;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Collide with Enemy");
            Destroy(gameObject, .5f);
        }
    }
}
