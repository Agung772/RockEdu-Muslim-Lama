using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetagameUI : MonoBehaviour
{
    public GameObject
        DU,
        RK,
        RM,
        RP;
    private void Start()
    {
        var GS = SaveManager.instance.GameSave;

        int scoreCTD = GS.scoreConnectingTheDot;
        int scoreSB = GS.scoreSpellingBee;
        int scorePG = GS.scorePilihanGanda;
        int scoreBS = GS.scoreBenarSalah;

        if (scoreCTD >= 2)
        {
            RM.gameObject.SetActive(false);
        }
        if (scorePG >= 2)
        {
            RK.gameObject.SetActive(false);
        }
        if (scoreBS >= 2)
        {
            RP.gameObject.SetActive(false);
        }
        if (scoreSB >= 2)
        {
            DU.gameObject.SetActive(false);
        }
    }
}
