using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDataBab : MonoBehaviour
{
    public int bab;
    public string namaBab;
    public Text totalBintangText, namaBabText;
    public Text cTDText, sBText, pGText, BSText;

    public Image bintangImage;
    public Sprite[] bintangSprite;

    private void Start()
    {
        LoadBabText();
    }

    public void LoadBabText()
    {
        /*
        cTDText.text = "CTD : " + PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreConnectingTheDot + bab + SaveManager.instance.GameSave.codeSave);
        sBText.text = "SB : " + PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreSpellingBee + bab + SaveManager.instance.GameSave.codeSave);
        pGText.text = "PG : " + PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScorePilihanGanda + bab + SaveManager.instance.GameSave.codeSave);
        BSText.text = "BS : " + PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreBenarSalah + bab + SaveManager.instance.GameSave.codeSave);
        */

        int cTD = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreConnectingTheDot + bab + SaveManager.instance.GameSave.codeSave);
        int sB = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreSpellingBee + bab + SaveManager.instance.GameSave.codeSave);
        int pG = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScorePilihanGanda + bab + SaveManager.instance.GameSave.codeSave);
        int bS = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreBenarSalah + bab + SaveManager.instance.GameSave.codeSave);

        int totalBintang = cTD + sB + pG + bS;

        namaBabText.text = namaBab;
        totalBintangText.text = "" + totalBintang;

        //Ganti bintang background
        if (totalBintang >= 10)
        {
            bintangImage.sprite = bintangSprite[2];
        }
        else if (totalBintang >= 5)
        {
            bintangImage.sprite = bintangSprite[1];
        }
        else if (totalBintang >= 0)
        {
            bintangImage.sprite = bintangSprite[0];
        }
    }
}
