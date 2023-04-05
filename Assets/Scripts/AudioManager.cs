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

    string SaveBgm = "SaveBgm";
    string SaveSfx = "SaveSfx";

    string StartSaveVolume = "StartSaveVolume";
    private void Awake()
    {
        instance = this;

        //Set volume untuk pertama kali
        if (PlayerPrefs.GetFloat(StartSaveVolume) == 0)
        {
            PlayerPrefs.SetFloat(StartSaveVolume, 1);

            PlayerPrefs.SetFloat(SaveBgm, 0.6f);
            PlayerPrefs.SetFloat(SaveSfx, 0.6f);

            print("Set volume untuk pertama kali");
        }


        volumeAudioBgm = PlayerPrefs.GetFloat(SaveBgm);
        volumeAudioSfx = PlayerPrefs.GetFloat(SaveSfx);


        print("audioSourceBgm " + PlayerPrefs.GetFloat(SaveBgm));
        print("volumeAudioSfx " + PlayerPrefs.GetFloat(SaveSfx));

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


    //Audio BGM
    [SerializeField]
    AudioClip
        bukaPintu,
        tutupPintu;

    public void BukaPintu() { if (bukaPintu != null) audioSourceSfx.PlayOneShot(bukaPintu); }
    public void TutupPintu() { if (tutupPintu != null) audioSourceSfx.PlayOneShot(tutupPintu); }


    //Audio BGM
    [SerializeField]
    AudioClip
        bgmConnectTheDots,
        bgmMetaGame,
        bgmHome;

    public void BgmConnectTheDots() { audioSourceBgm.clip = bgmConnectTheDots; audioSourceBgm.Play(); }
    public void BgmMetaGame() { audioSourceBgm.clip = bgmMetaGame; audioSourceBgm.Play(); }
    public void BgmHome() { audioSourceBgm.clip = bgmHome; audioSourceBgm.Play(); }


    //Audio SFX
    [SerializeField]
    AudioClip
        sfxPause,
        sfxUnpause;
    public void SfxPause() { if (sfxPause != null) audioSourceSfx.PlayOneShot(sfxPause); }
    public void SfxUnpause() { if (sfxUnpause != null) audioSourceSfx.PlayOneShot(sfxUnpause); }



    //Audio SFX CTD
    [SerializeField]
    AudioClip
        sfxScore,
        sfxGameOver,
        sfxHoldClick,
        sfxEnterMinigame,
        sfxBenar,
        sfxSalah;

    public void SfxScore() { if (sfxScore != null) audioSourceSfx.PlayOneShot(sfxScore); }
    public void SfxGameOver() { if (sfxGameOver != null) audioSourceSfx.PlayOneShot(sfxGameOver); }
    public void SfxHoldClick() { if (sfxHoldClick != null) audioSourceSfx.PlayOneShot(sfxHoldClick); }
    public void SfxEnterMinigame() { if (sfxEnterMinigame != null) audioSourceSfx.PlayOneShot(sfxEnterMinigame); }
    public void SfxBenar() { if (sfxBenar != null) audioSourceSfx.PlayOneShot(sfxBenar); }
    public void SfxSalah() { if (sfxSalah != null) audioSourceSfx.PlayOneShot(sfxSalah); }



    //Audio SFX PG
    [SerializeField]
    AudioClip
        sfxScorePG,
        sfxClickPG,
        sfxRocketPG,
        sfxConfettiPG,
        sfxBenarPG,
        sfxSalahPG;

    public void SfxScorePG() { if (sfxScorePG != null) audioSourceSfx.PlayOneShot(sfxScorePG); }
    public void SfxClickPG() { if (sfxClickPG != null) audioSourceSfx.PlayOneShot(sfxClickPG); }
    public void SfxRocketPG() { if (sfxRocketPG != null) audioSourceSfx.PlayOneShot(sfxRocketPG); }
    public void SfxConfettiPG() { if (sfxConfettiPG != null) audioSourceSfx.PlayOneShot(sfxConfettiPG); }
    public void SfxBenarPG() { if (sfxBenarPG != null) audioSourceSfx.PlayOneShot(sfxBenarPG); }
    public void SfxSalahPG() { if (sfxSalahPG != null) audioSourceSfx.PlayOneShot(sfxSalahPG); }



    //Audio SFX BS
    [SerializeField]
    AudioClip
        sfxScoreBS,
        sfxClickBS,
        sfxRocketBS,
        sfxConfettiBS,
        sfxBenarBS,
        sfxSalahBS;

    public void SfxScoreBS() { if (sfxScoreBS != null) audioSourceSfx.PlayOneShot(sfxScoreBS); }
    public void SfxClickBS() { if (sfxClickBS != null) audioSourceSfx.PlayOneShot(sfxClickBS); }
    public void SfxRocketBS() { if (sfxRocketBS != null) audioSourceSfx.PlayOneShot(sfxRocketBS); }
    public void SfxConfettiBS() { if (sfxConfettiBS != null) audioSourceSfx.PlayOneShot(sfxConfettiBS); }
    public void SfxBenarBS() { if (sfxBenarBS != null) audioSourceSfx.PlayOneShot(sfxBenarBS); }
    public void SfxSalahBS() { if (sfxSalahBS != null) audioSourceSfx.PlayOneShot(sfxSalahBS); }


    //Audio SFX BS
    [SerializeField]
    AudioClip
        sfxScoreSB,
        sfxClickSB,
        sfxRocketSB,
        sfxConfettiSB,
        sfxBenarSB,
        sfxSalahSB,
        sfxHurufJatuhSB,
        sfxStarSpraySB;


    public void SfxScoreSB() { if (sfxScoreSB != null) audioSourceSfx.PlayOneShot(sfxScoreSB); }
    public void SfxClickSB() { if (sfxClickSB != null) audioSourceSfx.PlayOneShot(sfxClickSB); }
    public void SfxRocketSB() { if (sfxRocketSB != null) audioSourceSfx.PlayOneShot(sfxRocketSB); }
    public void SfxConfettiSB() { if (sfxConfettiSB != null) audioSourceSfx.PlayOneShot(sfxConfettiSB); }
    public void SfxBenarSB() { if (sfxBenarSB != null) audioSourceSfx.PlayOneShot(sfxBenarSB); }
    public void SfxSalahSB() { if (sfxSalahSB != null) audioSourceSfx.PlayOneShot(sfxSalahSB); }
    public void SfxHurufJatuhSB() { if (sfxHurufJatuhSB != null) audioSourceSfx.PlayOneShot(sfxHurufJatuhSB); }
    public void SfxStarSpraySB() { if (sfxStarSpraySB != null) audioSourceSfx.PlayOneShot(sfxStarSpraySB); }


    //TesterVolume
    public void BgmTester() {  }
    public void SfxTester() { if (sfxPause != null) audioSourceSfx.PlayOneShot(sfxPause); }

}
