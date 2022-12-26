using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float timerTime;

    void Start()
    {
        timerText.text = timerTime.ToString("F2");       
    }

    void Update()
    {
        timerTime += Time.deltaTime;

        timerText.text = timerTime.ToString("F2");
    }
}
