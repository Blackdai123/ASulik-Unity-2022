using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerJoyStick : MonoBehaviour
{
    [SerializeField] FixedJoystick joyStick;
    [SerializeField] float speedMoving;
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStar;
    [SerializeField] GameObject threeStar;


    Vector2 track;
    float horizontalDirection;
    Animator animator;
    Vector2 nullVector = new Vector2(0, 0);
    Collider2D playerCollider;

    bool buffApplied;
    int appFishBuff;

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        oneStar.SetActive(false);
        twoStar.SetActive(false);
        threeStar.SetActive(false);
    }

    private void Update()
    {
        horizontalDirection = joyStick.Horizontal;

        if (horizontalDirection > 0)
        {
            MySingleton.Instance.GetSpritePlayer().flipX = false;
            playerCollider.offset = new Vector2(-0.07699f, -0.04737883f);
        }
        if (horizontalDirection < 0)
        {
            MySingleton.Instance.GetSpritePlayer().flipX = true;
            playerCollider.offset = new Vector2(0.07f, -0.04737883f);
        }
        else
        {
            MySingleton.Instance.GetSpritePlayer().flipX = MySingleton.Instance.GetSpritePlayer().flipX;
        }

        if (buffApplied && appFishBuff == 1)
        {
            oneStar.SetActive(true);
            buffApplied = false;

            speedMoving += 1.5f;
        }

        if (buffApplied && appFishBuff == 2)
        {
            oneStar.SetActive(false);
            twoStar.SetActive(true);
            buffApplied = false;

            speedMoving += 1.5f;
        }

        if (buffApplied && appFishBuff == 3)
        {
            twoStar.SetActive(false);
            threeStar.SetActive(true);
            buffApplied = false;

            speedMoving += 1.5f;
        }

        track = new Vector2(horizontalDirection, joyStick.Vertical) * speedMoving;

        Move(track);

        if (track.x > nullVector.x || track.y > nullVector.y)
        {
            CharacterAnimator.SetTrigger("Run");
        }

        if (track.x == nullVector.x || track.y == nullVector.y)
        {
            CharacterAnimator.SetTrigger("Idle");
        }

        if (track.x < nullVector.x || track.y < nullVector.y)
        {
            CharacterAnimator.SetTrigger("Run");
        }
    }
    private void Move(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            if (appFishBuff < 3)
            {
                appFishBuff++;

                buffApplied = true;
            }
        }
    }
}
