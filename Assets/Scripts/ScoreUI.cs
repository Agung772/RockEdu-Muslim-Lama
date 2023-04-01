using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    public Animator animatorBintang;
    public GameObject[] text;
    public GameObject confetti;

    public void CallScoreUI(int jumlahBintang)
    {
        if (jumlahBintang == 3)
        {
            text[3].SetActive(true);

            animatorBintang.SetTrigger("B3");

            confetti.SetActive(true);
        }
        else if (jumlahBintang == 2)
        {
            text[2].SetActive(true);

            animatorBintang.SetTrigger("B2");

            confetti.SetActive(true);
        }
        else if (jumlahBintang == 1)
        {
            text[1].SetActive(true);

            animatorBintang.SetTrigger("B1");
        }
        else if (jumlahBintang == 0)
        {
            text[0].SetActive(true);

            animatorBintang.SetTrigger("B0");
        }

        //Audio
        if (jumlahBintang != 0) 
        { 
            if (GameManager.instance.namaScene.ToString() == "ConnectingTheDot")
            {
                AudioManager.instance.SfxScore();
                AudioManager.instance.SfxConfettiSB();
            }
            else if (GameManager.instance.namaScene.ToString() == "SpellingBee")
            {
                AudioManager.instance.SfxScoreSB();
                AudioManager.instance.SfxConfettiSB();
            }
            else if (GameManager.instance.namaScene.ToString() == "PilihanGanda")
            {
                AudioManager.instance.SfxScorePG();
                AudioManager.instance.SfxConfettiPG();
            }
            else if (GameManager.instance.namaScene.ToString() == "BenarSalah")
            {
                AudioManager.instance.SfxScoreBS();
                AudioManager.instance.SfxConfettiBS();
            }
        }
        else AudioManager.instance.SfxGameOver();
    }
}
