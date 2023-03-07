using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public GameObject[] bintang;
    public GameObject[] text;

    public void CallScoreUI(int jumlahBintang)
    {
        if (jumlahBintang == 3)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(true);
            bintang[2].SetActive(true);

            text[3].SetActive(true);
        }
        else if (jumlahBintang == 2)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(true);
            bintang[2].SetActive(false);

            text[2].SetActive(true);
        }
        else if (jumlahBintang == 1)
        {
            bintang[0].SetActive(true);
            bintang[1].SetActive(false);
            bintang[2].SetActive(false);

            text[1].SetActive(true);
        }
        else if (jumlahBintang == 0)
        {
            bintang[0].SetActive(false);
            bintang[1].SetActive(false);
            bintang[2].SetActive(false);

            text[0].SetActive(true);
        }

        //Audio
        if (jumlahBintang != 0) AudioManager.instance.SfxScore();
        else AudioManager.instance.SfxGameOver();
    }
}
