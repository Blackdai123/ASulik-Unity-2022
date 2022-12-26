using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider slider;
    float musicVolume = 1f;

    void Start()
    {
        slider.GetComponent<Slider>();
        audioSource.GetComponent<AudioSource>();


        if (PlayerPrefs.HasKey("MusicValue")) 
        {
            musicVolume = PlayerPrefs.GetFloat("MusicValue");
            slider.value = musicVolume;
        }
    }

    void Update()
    {
        audioSource.volume = musicVolume; 
        PlayerPrefs.SetFloat("MusicValue", musicVolume);
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
