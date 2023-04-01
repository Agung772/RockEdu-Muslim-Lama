using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameplayConnectingTheDot : MonoBehaviour
{
    public static GameplayConnectingTheDot instance;
    public int batrai = 3;
    public int bab;

    public GameObject batraiUI;

    public GameObject[] soalBab;

    public DotController[] dotController;
    public EndDot[] endDot;


    private void Awake()
    {
        instance = this;

        bab = SaveManager.instance.GameSave.bab;
        LoadBab();

        dotController = FindObjectsOfType<DotController>();
        endDot = FindObjectsOfType<EndDot>();

        //Random color di Dot
        RandomSD();
        if (!endDot[0].tidakDiAcak) RandomED();
    }

    void LoadBab()
    {
        for (int i = 0; i < soalBab.Length; i++)
        {
            if (i != 0)
            {
                soalBab[i].SetActive(false);
            }
        }

        if (bab == 1)
        {
            soalBab[1].SetActive(true);
        }
        else if (bab == 2)
        {
            soalBab[2].SetActive(true);
        }
        else if (bab == 3)
        {
            soalBab[3].SetActive(true);
        }
        else if (bab == 4)
        {
            soalBab[4].SetActive(true);
        }
        else if (bab == 5)
        {
            soalBab[5].SetActive(true);
        }
        else if (bab == 6)
        {
            soalBab[6].SetActive(true);
        }
        else if (bab == 7)
        {
            soalBab[7].SetActive(true);
        }
        else if (bab == 8)
        {
            soalBab[8].SetActive(true);
        }
        else if (bab == 9)
        {
            soalBab[9].SetActive(true);
        }
        else if (bab == 10)
        {
            soalBab[10].SetActive(true);
        }
    }

    //Semua dot sudah terpasang
    public void ChechDot()
    {
        int checkDot = 0;
        for (int i = 0; i < dotController.Length; i++)
        {
            if (dotController[i].clear) checkDot++;
        }
        if (checkDot == dotController.Length)
        {
            //Save score
            SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScoreConnectingTheDot, batrai);
            AnimasiManager.instance.AnimasiScreenCTD(false);


            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(1);
                ButtonManager.instance.SpawnScoreUI(batrai);
                yield return new WaitForSeconds(2);
                AudioManager.instance.SfxConfettiBS();
            }
        }
    }

    //Baterai habis
    public void SalahDot()
    {
        batrai--;

        if (batrai == 2)
        {

            batraiUI.transform.GetChild(5).GetComponent<Animator>().SetTrigger("Exit");
        }
        else if (batrai == 1)
        {

            batraiUI.transform.GetChild(4).GetComponent<Animator>().SetTrigger("Exit");
        }
        else if (batrai == 0)
        {

            batraiUI.transform.GetChild(3).GetComponent<Animator>().SetTrigger("Exit");

            AnimasiManager.instance.AnimasiScreenCTD(false);

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(1);
                ButtonManager.instance.SpawnScoreUI(batrai);
                yield return new WaitForSeconds(2);
                AudioManager.instance.SfxConfettiBS();
            }

        }

    }
    //Random Start Dot
    int randomSD;
    bool[] randomSDBool;
    public float[] positionYSD;
    void RandomSD()
    {
        randomSDBool = new bool[dotController.Length];
        positionYSD = new float[dotController.Length];

        for (int i = 0; i < randomSDBool.Length; i++)
        {
            positionYSD[i] = dotController[i].transform.position.y;
        }

        for (int i = 0; i < randomSDBool.Length; i++)
        {
            RandomSDVoid();
            dotController[i].transform.localPosition = new Vector3(0, positionYSD[randomSD], 0);
        }

        void RandomSDVoid()
        {
            randomSD = Random.Range(0, randomSDBool.Length);
            if (randomSD == 0 && !randomSDBool[0]) randomSDBool[0] = true;
            else if (randomSD == 1 && !randomSDBool[1]) randomSDBool[1] = true;
            else if (randomSD == 2 && !randomSDBool[2]) randomSDBool[2] = true;
            else if (randomSD == 3 && !randomSDBool[3]) randomSDBool[3] = true;
            else if (randomSD == 4 && !randomSDBool[4]) randomSDBool[4] = true;
            else if (randomSD == 5 && !randomSDBool[5]) randomSDBool[5] = true;
            else RandomSDVoid();

        }
    }

    //Random Start Dot
    int randomED;
    bool[] randomEDBool;
    public float[] positionYED;
    void RandomED()
    {
        randomEDBool = new bool[endDot.Length];
        positionYED = new float[endDot.Length];

        for (int i = 0; i < randomEDBool.Length; i++)
        {
            positionYED[i] = endDot[i].transform.position.y;
        }

        for (int i = 0; i < randomEDBool.Length; i++)
        {
            RandomEDVoid();
            endDot[i].transform.localPosition = new Vector3(0, positionYED[randomED], 0);
        }

        void RandomEDVoid()
        {
            randomED = Random.Range(0, randomEDBool.Length);
            if (randomED == 0 && !randomEDBool[0]) randomEDBool[0] = true;
            else if (randomED == 1 && !randomEDBool[1]) randomEDBool[1] = true;
            else if (randomED == 2 && !randomEDBool[2]) randomEDBool[2] = true;
            else if (randomED == 3 && !randomEDBool[3]) randomEDBool[3] = true;
            else if (randomED == 4 && !randomEDBool[4]) randomEDBool[4] = true;
            else if (randomED == 5 && !randomEDBool[5]) randomEDBool[5] = true;
            else RandomEDVoid();


        }
    }
}
