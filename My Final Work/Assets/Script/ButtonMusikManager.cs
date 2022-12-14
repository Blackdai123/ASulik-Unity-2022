using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMusikManager : MonoBehaviour
{
    [SerializeField] Button buttonMusicOff;
    [SerializeField] AudioSource audioSourse;

    bool isActived;

    void Start()
    {
        buttonMusicOff.GetComponent<Button>();
        audioSourse.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (buttonMusicOff.gameObject.activeSelf == true)
        {
            audioSourse.mute = true;
        }

        if (buttonMusicOff.gameObject.activeSelf == false)
        {
            audioSourse.mute = false;
        }
    }

}
