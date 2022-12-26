using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chooting : MonoBehaviour
{
    [SerializeField] GameObject firsWeapon;
    [SerializeField] GameObject secondWeapon;
    [SerializeField] GameObject thirdWeapon;
    [SerializeField] GameObject player;
    [SerializeField] float timeToShot;
    [SerializeField] float shotRange;
    [SerializeField] float speedShoting;
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStar;
    [SerializeField] GameObject threeStar;
    

    float timer;
    bool isStartedFirst;
    bool isStartedSecond;
    bool buffWillApply = true;
    int secondWeaponIsReadu;
    Vector2 endPosFirstWeapon;
    Vector2 startPosFirstWeapon;
    Vector2 endPosSecondWeapon;
    Vector2 startPosSecondWeapon;
    float progress;
    SpriteRenderer weaponSpriteFirstWeapon;
    SpriteRenderer weaponSpriteSecondWeapon;

    void Start()
    {
        firsWeapon.SetActive(false);
        secondWeapon.SetActive(false);
        oneStar.SetActive(false);
        twoStar.SetActive(false);
        threeStar.SetActive(false);

        timer = timeToShot;
        weaponSpriteFirstWeapon = firsWeapon.GetComponent<SpriteRenderer>();
        weaponSpriteSecondWeapon = secondWeapon.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer -=Time.deltaTime;
        if (timer <= 0)
        {
            if (!isStartedFirst)
            {
                endPosFirstWeapon = EndPosWeaponEnderFirstWeapon();
                startPosFirstWeapon = StartPosWeaponEnder();
                
                firsWeapon.SetActive(true);

                isStartedFirst = true;
            }

            if (!isStartedSecond && secondWeaponIsReadu >= 1)
            {
                endPosSecondWeapon = EndPosWeaponEnderSecondWeapon();
                startPosSecondWeapon = StartPosWeaponEnder();

                if (secondWeaponIsReadu == 1)
                {
                    oneStar.SetActive(true);
                }
                
                secondWeapon.SetActive(true);

                isStartedSecond = true;
            }

            if (secondWeaponIsReadu == 2)
            {
                oneStar.SetActive(false);
                twoStar.SetActive(true);

                firsWeapon.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
                secondWeapon.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            }

            if (secondWeaponIsReadu == 3 && buffWillApply)
            {
                speedShoting *= 2.5f;

                twoStar.SetActive(false);
                threeStar.SetActive(true);

                buffWillApply = false;
            }

            firsWeapon.transform.position = Vector3.Lerp(startPosFirstWeapon, endPosFirstWeapon, progress);
            secondWeapon.transform.position = Vector3.Lerp(startPosSecondWeapon, endPosSecondWeapon, progress);

            progress += speedShoting;

            if (progress>=1)
            {
                firsWeapon.SetActive(false);
                secondWeapon.SetActive(false);
                progress = 0;
                timer = timeToShot;
                isStartedFirst = false;
                isStartedSecond = false;
            }
        }
    }

    Vector2 EndPosWeaponEnderFirstWeapon()
    {

        if (MySingleton.Instance.GetSpritePlayer().flipX)
        {
            endPosFirstWeapon = new Vector2(player.transform.position.x - shotRange, player.transform.position.y);
            weaponSpriteFirstWeapon.flipX = true;
        }
        else
        {
            endPosFirstWeapon = new Vector2(player.transform.position.x + shotRange, player.transform.position.y);
            weaponSpriteFirstWeapon.flipX = false;
        }

        return endPosFirstWeapon;
    }

    Vector2 EndPosWeaponEnderSecondWeapon()
    {
        if (MySingleton.Instance.GetSpritePlayer().flipX)
        {
            startPosFirstWeapon = new Vector2(player.transform.position.x + shotRange, player.transform.position.y);
            weaponSpriteSecondWeapon.flipX = false;
        }
        else
        {
            startPosFirstWeapon = new Vector2(player.transform.position.x - shotRange, player.transform.position.y);
            weaponSpriteSecondWeapon.flipX = true;
        }

        return startPosFirstWeapon;
    }

    Vector2 StartPosWeaponEnder()
    {
        startPosFirstWeapon = new Vector2(player.transform.position.x, player.transform.position.y);
        return startPosFirstWeapon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HatBuff"))
        {
            if (secondWeaponIsReadu<3)
            {
                secondWeaponIsReadu++;
            }
        }
    }
}
