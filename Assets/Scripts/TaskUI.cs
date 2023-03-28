using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour
{
    public GameObject 
        textTugasCTD,
        textTugasSB,
        textTugasPG,
        textTugasBS;

    private void OnEnable()
    {
        int scoreCTD = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreConnectingTheDot + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);
        int scoreSB = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreSpellingBee + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);
        int scorePG = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScorePilihanGanda + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);
        int scoreBS = PlayerPrefs.GetInt(SaveManager.instance.GameSave._ScoreBenarSalah + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);

        //-------------CTD----------------
        if (scoreCTD >= 2)
        {
            textTugasCTD.transform.GetChild(0).gameObject.SetActive(false);
            textTugasCTD.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            textTugasCTD.transform.GetChild(0).gameObject.SetActive(true);
            textTugasCTD.transform.GetChild(1).gameObject.SetActive(false);
        }

        //-------------SB----------------
        if (scoreSB >= 2)
        {
            textTugasSB.transform.GetChild(0).gameObject.SetActive(false);
            textTugasSB.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            textTugasSB.transform.GetChild(0).gameObject.SetActive(true);
            textTugasSB.transform.GetChild(1).gameObject.SetActive(false);
        }

        //-------------PG----------------
        if (scorePG >= 2)
        {
            textTugasPG.transform.GetChild(0).gameObject.SetActive(false);
            textTugasPG.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            textTugasPG.transform.GetChild(0).gameObject.SetActive(true);
            textTugasPG.transform.GetChild(1).gameObject.SetActive(false);
        }

        //-------------BS----------------
        if (scoreBS >= 2)
        {
            textTugasBS.transform.GetChild(0).gameObject.SetActive(false);
            textTugasBS.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            textTugasBS.transform.GetChild(0).gameObject.SetActive(true);
            textTugasBS.transform.GetChild(1).gameObject.SetActive(false);
        }

    }
}
