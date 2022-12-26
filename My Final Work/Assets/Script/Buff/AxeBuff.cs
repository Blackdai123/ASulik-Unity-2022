using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBuff : MonoBehaviour
{
    [SerializeField] GameObject axeMain;
    [SerializeField] GameObject firsAxe;
    [SerializeField] GameObject secondAxe;
    [SerializeField] float speedRotate;
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStar;
    [SerializeField] GameObject threeStar;

    int appAxeBuff;
    bool buffApplied;

    void Start()
    {
        axeMain.SetActive(false);
        firsAxe.SetActive(false);
        secondAxe.SetActive(false);
        oneStar.SetActive(false);
        twoStar.SetActive(false);
        threeStar.SetActive(false);
    }

    void Update()
    {
        if (axeMain)
        {
            axeMain.transform.Rotate(0, 0, 1 * speedRotate);
        }
       
        if (!buffApplied && appAxeBuff==1)
        {
            axeMain.SetActive(true);
            firsAxe.SetActive(true);
            oneStar.SetActive(true);

            buffApplied = true;
        }

        if (!buffApplied && appAxeBuff == 2)
        {
            secondAxe.SetActive(true);
            oneStar.SetActive(false);
            twoStar.SetActive(true);

            buffApplied = true;
        }

        if (!buffApplied && appAxeBuff == 3)
        {
            twoStar.SetActive(false);
            threeStar.SetActive(true);

            speedRotate += 0.2f;
            buffApplied = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Axe"))
        {
            if (appAxeBuff<3)
            {
                appAxeBuff++;
                buffApplied = false;
            }
        }
    }
}
