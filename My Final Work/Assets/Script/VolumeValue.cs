using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    float musicVolume = 1f;

    void Start()
    {
        audioSource.GetComponent<AudioSource>();    
    }

    void Update()
    {
        audioSource.volume = musicVolume;        
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
