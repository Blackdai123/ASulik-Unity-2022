using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chooting : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject player;
    [SerializeField] float timeToShot;
    [SerializeField] float shotRange;
    [SerializeField] float speedShoting;

    float timer;
    bool isStarted;
    Vector2 endPos;
    Vector2 startPos;
    float progress;
    SpriteRenderer weaponSprite;

    void Start()
    {
        weapon.SetActive(false);

        timer = timeToShot;
        weaponSprite = weapon.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer -=Time.deltaTime;
        if (timer <= 0)
        {
            if (!isStarted)
            {
                endPos = EndPosWeaponEnder();
                startPos = StartPosWeaponEnder();
                
                weapon.SetActive(true);

                isStarted = true;
            }

            weapon.transform.position = Vector3.Lerp(startPos, endPos, progress);

            progress += speedShoting;

            if (progress>=1)
            {
                weapon.SetActive(false);
                progress = 0;
                timer = timeToShot;
                isStarted = false;
            }
        }
    }

    Vector2 EndPosWeaponEnder()
    {

        if (MySingleton.Instance.GetSpritePlayer().flipX)
        {
            endPos = new Vector2(player.transform.position.x - shotRange, player.transform.position.y);
            weaponSprite.flipX = true;
        }
        else
        {
            endPos = new Vector2(player.transform.position.x + shotRange, player.transform.position.y);
            weaponSprite.flipX = false;
        }

        return endPos;
    }

    Vector2 StartPosWeaponEnder()
    {
        startPos = new Vector2(player.transform.position.x, player.transform.position.y);
        return startPos;
    }
}
