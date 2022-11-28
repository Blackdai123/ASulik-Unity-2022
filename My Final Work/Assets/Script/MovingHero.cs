using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHero : MonoBehaviour
{
    Vector2 track;

    void Update()
    {
        track = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(track);
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime);
    }
}
