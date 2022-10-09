using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlepPlayer : MonoBehaviour
{
    private SpriteRenderer render;
    
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            render.flipX = !render.flipX;
        }
    }
}
