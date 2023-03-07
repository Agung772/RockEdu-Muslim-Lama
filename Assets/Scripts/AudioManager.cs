using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
 
    public float volumeAudioBgm;
    public float volumeAudioSfx;

    public Slider volumeSliderBgm;
    public Slider volumeSliderSfx;

    public AudioSource audioSourceBgm;
    public AudioSource audioSourceSfx;

    //Input Audio
    public AudioClip bgmConnectTheDots;

    public AudioClip sfxScore, sfxGameOver, sfxHoldClick, sfxEnterMinigame, sfxPause, sfxUnpause ,sfxBenar, sfxSalah;

    string SaveBgm = "SaveBgm";
    string SaveSfx = "SaveSfx";

    string StartSaveVolume = "StartSaveVolume";
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Set volume untuk pertama kali
        if (PlayerPrefs.GetFloat(StartSaveVolume) == 0)
        {
            PlayerPrefs.SetFloat(StartSaveVolume, 1);

            PlayerPrefs.SetFloat(SaveBgm, 0.6f);
            PlayerPrefs.SetFloat(SaveSfx, 0.6f);
        }


        volumeAudioBgm = PlayerPrefs.GetFloat(SaveBgm);
        volumeAudioSfx = PlayerPrefs.GetFloat(SaveSfx);

        audioSourceBgm.volume = volumeAudioBgm;
        audioSourceSfx.volume = volumeAudioSfx;
    }

    public void VolumeValueBgm(float value)
    {
        volumeAudioBgm = value;
        audioSourceBgm.volume = value;
        PlayerPrefs.SetFloat(SaveBgm, volumeAudioBgm);
    }
    public void RefrensBgm(Slider slider)
    {
        volumeSliderBgm = slider;
        volumeSliderBgm.value = volumeAudioBgm;
    }

    public void VolumeValueSfx(float value)
    {
        volumeAudioSfx = value;
        audioSourceSfx.volume = value;
        PlayerPrefs.SetFloat(SaveSfx, volumeAudioSfx);
    }
    public void RefrensSfx(Slider slider)
    {
        volumeSliderSfx = slider;
        volumeSliderSfx.value = volumeAudioSfx;
    }



    public void BgmConnectTheDots() { audioSourceBgm.clip = bgmConnectTheDots; audioSourceBgm.Play(); }


    public void SfxScore() { if (sfxScore != null) audioSourceSfx.PlayOneShot(sfxScore); }
    public void SfxGameOver() { if (sfxGameOver != null) audioSourceSfx.PlayOneShot(sfxGameOver); }
    public void SfxHoldClick() { if (sfxHoldClick != null) audioSourceSfx.PlayOneShot(sfxHoldClick); }
    public void SfxEnterMinigame() { if (sfxEnterMinigame != null) audioSourceSfx.PlayOneShot(sfxEnterMinigame); }
    public void SfxPause() { if (sfxPause != null) audioSourceSfx.PlayOneShot(sfxPause); }
    public void SfxUnpause() { if (sfxUnpause != null) audioSourceSfx.PlayOneShot(sfxUnpause); }
    public void SfxBenar() { if (sfxBenar != null) audioSourceSfx.PlayOneShot(sfxBenar); }
    public void SfxSalah() { if (sfxSalah != null) audioSourceSfx.PlayOneShot(sfxSalah); }

}
