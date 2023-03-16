using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public GameObject restartUI, quitUI, optionUI;
    bool restart, quit;

    public Slider sliderBgm;
    public Slider sliderSfx;
    private void Start()
    {
        RefrensBgm(sliderBgm);
        RefrensSfx(sliderSfx);
    }
    public void RestartUI()
    {
        restartUI.SetActive(true);
        optionUI.SetActive(false);
        restart = true;

    }
    public void QuitUI()
    {
        quitUI.SetActive(true);
        optionUI.SetActive(false);
        quit = true;
    }
    public void No()
    {
        if(restart == true)
        {
            restartUI.SetActive(false);
            optionUI.SetActive(true);
            restart = false;
        }
        if(quit == true)
        {
            quitUI.SetActive(false);
            optionUI.SetActive(true);
            quit = false;
        }

    }


    public void VolumeValueBgm(float value)
    {
        if (gameObject.activeInHierarchy)
        {
            AudioManager.instance.VolumeValueBgm(value);
        }

    }
    public void RefrensBgm(Slider slider)
    {
        AudioManager.instance.RefrensBgm(slider);
    }
    public void VolumeValueSfx(float value)
    {
        if (gameObject.activeInHierarchy)
        {
            AudioManager.instance.VolumeValueSfx(value);
        }

    }
    public void RefrensSfx(Slider slider)
    {
        AudioManager.instance.RefrensSfx(slider);
    }

    public void BgmTester() { if (gameObject.activeInHierarchy) AudioManager.instance.BgmTester(); }
    public void SfxTester() { if (gameObject.activeInHierarchy) AudioManager.instance.SfxTester(); }

}
