using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    public Animator animatorBintang;
    public GameObject[] text;

    public void CallScoreUI(int jumlahBintang)
    {
        if (jumlahBintang == 3)
        {
            text[3].SetActive(true);

            animatorBintang.SetTrigger("B3");
        }
        else if (jumlahBintang == 2)
        {
            text[2].SetActive(true);

            animatorBintang.SetTrigger("B2");
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
        if (jumlahBintang != 0) AudioManager.instance.SfxScore();
        else AudioManager.instance.SfxGameOver();
    }
}
