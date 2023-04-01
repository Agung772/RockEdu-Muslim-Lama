using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        float volume = AudioManager.instance.volumeAudioSfx;
        audioSource.volume = volume / 4;
    }
}
