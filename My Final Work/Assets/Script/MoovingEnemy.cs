using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingEnemy : MonoBehaviour
{
    //[SerializeField] GameObject player;

    [SerializeField] float health = 100;

    [SerializeField] float speed = 1.0f;

    Vector2 playerPos;

    void Update()
    {
        //transform.position = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime);

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        playerPos = MySingleton.Instance.PlayerPosition();

        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            health -= 50;
        }
    }
}
