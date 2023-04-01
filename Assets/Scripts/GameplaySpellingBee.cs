using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public struct Bab
{
    public GameObject[] soal;
}
public class GameplaySpellingBee : MonoBehaviour
{
    public static GameplaySpellingBee instance;

    public int bab, urutanSoal;
    public int baterai = 2;
    public bool finis;
    public int checkTotal, checkTotalClear;

    public List<Bab> babList;

    public Text bateraiText;
    public GameObject bateraiUI1, bateraiUI2;
    public GameObject benarUI;
    public GameObject starSpray;
    public Animator transisiNextSB;

    public SlotHurufController[] slotHurufController;
    public HurufController[] hurufController;

    public SlotHurufController[] AwalslotHurufController;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Load bab
        bab = SaveManager.instance.GameSave.bab;
        babList[bab].soal[0].SetActive(true);

        NextSoal(bab);
        BateraiUI();
        UrutanSoalUI();
    }

    [SerializeField]
    float resetTime;
    private void Update()
    {
        if (resetTime < 2)
        {
            resetTime += Time.deltaTime;
        }
    }

    public void NextSoal(int bab)
    {
        //Soal udah habis
        if (urutanSoal == babList[bab].soal.Length - 1)
        {
            if (baterai == 2)
            {
                ButtonManager.instance.SpawnScoreUI(3);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScoreSpellingBee, 3);

            }
            else if (baterai == 1)
            {
                ButtonManager.instance.SpawnScoreUI(2);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScoreSpellingBee, 2);
            }
            finis = true;

        }
        //Lanjut soal berikutnya
        else
        {
            //Reset baterai
            baterai = 2;
            BateraiUI();


            //Nonaktifkan soal sebelumnya
            for (int i = 0; i < babList[bab].soal.Length; i++)
            {
                if (i != 0) babList[bab].soal[i].SetActive(false);

            }

            urutanSoal++;
            UrutanSoalUI();
            babList[bab].soal[urutanSoal].SetActive(true);


            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(0.1f);
                slotHurufController = FindObjectsOfType<SlotHurufController>();
                hurufController = FindObjectsOfType<HurufController>();
            }
        }

 
    }

    public void CheckHuruf()
    {
        StartCoroutine(CoroutineCheck());
        IEnumerator CoroutineCheck()
        {
            yield return new WaitForSeconds(0.1f);

            //CheckTotal yang ke use dan clear
            checkTotal = 0;
            checkTotalClear = 0;
            for (int i = 0; i < slotHurufController.Length; i++)
            {
                if (slotHurufController[i].use)
                {
                    checkTotal++;

                }
                if (slotHurufController[i].clear)
                {
                    checkTotalClear++;
                }
            }

            //Semua slot keisi
            if (slotHurufController.Length == checkTotal && resetTime >= 2)
            {
                resetTime = 0;

                //Check benar semua
                if (slotHurufController.Length == checkTotalClear)
                {
                    BenarUI();
                }

                //Reset karena salah
                else
                {
                    print("gagal, ngulang cuy");
                    //Update untuk UI Baterai
                    baterai--;
                    BateraiUI();

                    //Semua baterai habis
                    if (baterai == 0)
                    {
                        ButtonManager.instance.SpawnScoreUI(0);
                        finis = true;
                    }

                    //Reset
                    for (int i = 0; i < slotHurufController.Length; i++)
                    {
                        slotHurufController[i].gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    }

                    StartCoroutine(Coroutine());
                    IEnumerator Coroutine()
                    {
                        yield return new WaitForSeconds(0.5f);
                        for (int i = 0; i < slotHurufController.Length; i++)
                        {
                            slotHurufController[i].gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = false;
                        }
                    }

                    //Kembalikan huruf tempat awal

                    for (int i = 0; i < hurufController.Length; i++)
                    {
                        hurufController[i].back = true;
                    }
                }
            }

            checkTotal = Mathf.Clamp(checkTotal, 0, slotHurufController.Length);
            checkTotalClear = Mathf.Clamp(checkTotalClear, 0, slotHurufController.Length);
        }
    }

    void BateraiUI()
    {
        if (baterai == 2)
        {
            bateraiUI1.SetActive(true);
            bateraiUI2.SetActive(true);
        }
        else if (baterai == 1)
        {
            bateraiUI1.SetActive(true);
            bateraiUI2.SetActive(false);
        }
        else if (baterai == 0)
        {
            bateraiUI1.SetActive(false);
            bateraiUI2.SetActive(false);
        }
    }

    void UrutanSoalUI()
    {
        bateraiText.text = urutanSoal + "/" + 5;
    }

    void BenarUI()
    {



        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            if (urutanSoal != babList[bab].soal.Length - 1)
            {
                transisiNextSB.SetTrigger("Benar");
                yield return new WaitForSeconds(1);
                AudioManager.instance.SfxBenarSB();
                NextSoal(bab);
                yield return new WaitForSeconds(2);
                starSpray.SetActive(true);
                AudioManager.instance.SfxStarSpraySB();
            }
            else
            {
                NextSoal(bab);
            }

        }

    }
}
