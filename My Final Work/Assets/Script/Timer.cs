using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMPro.TMP_Text timerText;

    float timerTime;
    float previousValue;

    void Start()
    {
        if (PlayerPrefs.HasKey("MaxTime"))
        {
            previousValue = PlayerPrefs.GetFloat("MaxTime");
        }
        
        timerText.text = timerTime.ToString("F2");       
    }

    void Update()
    {
        timerTime += Time.deltaTime;

        timerText.text = timerTime.ToString("F2");

        if (previousValue < timerTime)
        {
            PlayerPrefs.SetFloat("MaxTime", timerTime);
        }
    }
}
