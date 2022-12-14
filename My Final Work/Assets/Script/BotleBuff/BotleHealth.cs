using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotleHealth : BotleSingleton<BotleHealth>
{
    [SerializeField] float restoreHealth;

    public float BotleRestoreHealth()
    {
        return restoreHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
