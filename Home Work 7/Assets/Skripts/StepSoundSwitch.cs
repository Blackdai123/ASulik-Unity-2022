using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StepSoundSwitch : MonoBehaviour
{
    public AudioSource audioSourse;
    public AudioClip clip;

    private bool plaing = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            plaing = true;
            StartAudio();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            plaing = true;
            StartAudio();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            plaing = true;
            StartAudio();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            plaing = true;
            StartAudio();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            plaing = true;
            StartAudio();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            plaing = true;
            StartAudio();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            plaing = true;
            StartAudio();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            plaing = true;
            StartAudio();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            plaing = false;
            StartAudio();
        }


        
    }

    private void StartAudio()
    {
        audioSourse.PlayOneShot(clip);
    }
}
