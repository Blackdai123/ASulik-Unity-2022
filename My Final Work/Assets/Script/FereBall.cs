using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FereBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
