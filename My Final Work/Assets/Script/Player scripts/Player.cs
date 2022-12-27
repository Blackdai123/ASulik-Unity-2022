using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health;

    private void Update()
    {
        if (health<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 20;
        }

        if (collision.gameObject.CompareTag("BotleBuff"))
        {
            var botleHeal = collision.gameObject.GetComponent<BotleHealth>();

            health += botleHeal.BotleRestoreHealth();

            if (health > 100)
            {
                health = 100f;
            }
        }
    }
}
