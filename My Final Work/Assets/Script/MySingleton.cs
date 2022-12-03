using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton : Singleton<MySingleton>
{
    Vector2 playerPos;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public Vector2 PlayerPosition()
    {
        playerPos = new Vector2(transform.position.x, transform.position.y);
        return playerPos;
    }
    
    public SpriteRenderer GetSpritePlayer()
    {
        return spriteRenderer;
    }
}
