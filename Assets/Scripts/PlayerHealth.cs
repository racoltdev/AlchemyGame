using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    void Start()
    {
        health = 1;
    }

    void Update()
    {
        if (health <= 0)
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Collide with Enemy");
            health--;
        }
    }
}
