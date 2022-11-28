using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] float health = 100; 
    
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime);

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            health -= 50;
        }
    }
}
