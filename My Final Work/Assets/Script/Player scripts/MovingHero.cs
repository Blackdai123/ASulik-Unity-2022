using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHero : MonoBehaviour
{
    [SerializeField] float speedMoving;

    Vector2 track;
    float horizontalDirection;
    Animator animator;
    Vector2 s = new Vector2(0,0);

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");

        if (horizontalDirection > 0)
        {
            MySingleton.Instance.GetSpritePlayer().flipX = false;
        }
        if(horizontalDirection < 0)
        {
            MySingleton.Instance.GetSpritePlayer().flipX = true;
        }
        else
        {
            MySingleton.Instance.GetSpritePlayer().flipX = MySingleton.Instance.GetSpritePlayer().flipX;
        }

        track = new Vector2(horizontalDirection, Input.GetAxis("Vertical")) * speedMoving;

        Move(track);

        if (track.x > s.x || track.y > s.y)
        {
            CharacterAnimator.SetTrigger("Run");
        }

        if (track.x == s.x || track.y == s.y)
        {
            CharacterAnimator.SetTrigger("Idle");
        }

        if (track.x < s.x || track.y < s.y)
        {
            CharacterAnimator.SetTrigger("Run");
        }
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime);
    }
}
