using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTimeDisplay : MonoBehaviour
{
    public TMPro.TMP_Text timerText;

    float bestTime;

    void Start()
    {

        if (PlayerPrefs.HasKey("MaxTime"))
        {
            bestTime = PlayerPrefs.GetFloat("MaxTime");
            timerText.text = "Best time: " + bestTime.ToString("F2");
        }
        else
        {
            timerText.text = "Best Time: - ";
        }
    }

}
