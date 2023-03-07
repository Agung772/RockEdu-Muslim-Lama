using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDataBab : MonoBehaviour
{
    public int bab;
    public Text totalBintangText;
    public Text cTDText, sBText, pGText, BSText;

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
        totalBintangText.text = "" + totalBintang;
    }
}
