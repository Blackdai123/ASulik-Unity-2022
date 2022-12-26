using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingEnemy : MonoBehaviour
{

    [SerializeField] float health = 100;

    [SerializeField] float speed = 1.0f;

    Vector2 playerPos;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (health <= 0)
        {
            if (BuffManager.Instance.readinessBotleBuff)
            {
                BuffManager.Instance.InstanceBotleBuff(transform);
            }

            if (BuffManager.Instance.readinessBuff)
            {
                BuffManager.Instance.InstanceBuff(transform);
            }

            gameObject.SetActive(false);
        }

        playerPos = MySingleton.Instance.PlayerPosition();

        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

        if (transform.position.x - playerPos.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        if (transform.position.x - playerPos.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = spriteRenderer.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            health -= 50;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Axe"))
        {
            health -= 50;
        }
    }
}
