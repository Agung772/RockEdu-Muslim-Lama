using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GameplayBenarSalah : MonoBehaviour
{
    public static GameplayBenarSalah instance;

    public int bab;
    public int urutanPertanyaan, benar, salah;

    public GameObject benarSalahPrefab;
    public Transform spawnSoal;

    public Animator transisiNext;
    public Animator bgBenarSalah;

    [Serializable]
    public struct ListPertanyaan
    {
        public string pertanyaan;
        public string jawaban;
    }
    public List<ListPertanyaan> listPertanyaanBab1;
    public List<ListPertanyaan> listPertanyaanBab2;
    public List<ListPertanyaan> listPertanyaanBab3;
    public List<ListPertanyaan> listPertanyaanBab4;
    public List<ListPertanyaan> listPertanyaanBab5;
    public List<ListPertanyaan> listPertanyaanBab6;
    public List<ListPertanyaan> listPertanyaanBab7;
    public List<ListPertanyaan> listPertanyaanBab8;
    public List<ListPertanyaan> listPertanyaanBab9;
    public List<ListPertanyaan> listPertanyaanBab10;

    public int jumlahSoal;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerPrefs.SetInt(SaveManager.instance.GameSave._Bab, 1);

        bab = SaveManager.instance.GameSave.bab;

        if (bab == 1 || bab == 2 || bab == 3 || bab == 5 || bab == 6 || bab == 7 || bab == 8 || bab == 9 || bab == 10) jumlahSoal = 5;
        else if (bab == 4) jumlahSoal = 10;

    }

    //Memunculkan pertanyaan berdasarkan bab
    public void NextPertanyaan(int delay)
    {
        //Pertanyaan sudah habis 
        //Saving score
        if (urutanPertanyaan == jumlahSoal)
        {
            if (benar == 0)
            {
                ButtonManager.instance.SpawnScoreUI(0);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScoreBenarSalah, 0);
            }
            else if (benar < (jumlahSoal / 2) + 1)
            {
                ButtonManager.instance.SpawnScoreUI(1);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScoreBenarSalah, 1);
            }
            else if (benar < jumlahSoal)
            {
                ButtonManager.instance.SpawnScoreUI(2);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScoreBenarSalah, 2);
            }
            else if (benar == jumlahSoal)
            {
                ButtonManager.instance.SpawnScoreUI(3);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScoreBenarSalah, 3);
            }


        }
        //Next pertanyaan
        else
        {

            if (spawnSoal.childCount != 0)
            {
                string condition = spawnSoal.GetChild(0).gameObject.GetComponent<BenarSalah>().condition;
                if (condition == "Benar")
                {
                    TransisiNext("Benar");
                }
                else
                {
                    TransisiNext("Salah");
                }

                StartCoroutine(CoroutineA());
                IEnumerator CoroutineA()
                {
                    yield return new WaitForSeconds(delay);
                    //Destroy soal sebelumnnya
                    Destroy(spawnSoal.GetChild(0).gameObject);
                }

            }

            urutanPertanyaan++;


            if (bab == 1)
            {
                SpawnBenarSalah(listPertanyaanBab1[urutanPertanyaan].pertanyaan, listPertanyaanBab1[urutanPertanyaan].jawaban);
            }
            else if (bab == 2)
            {
                SpawnBenarSalah(listPertanyaanBab2[urutanPertanyaan].pertanyaan, listPertanyaanBab2[urutanPertanyaan].jawaban);
            }
            else if (bab == 3)
            {
                SpawnBenarSalah(listPertanyaanBab3[urutanPertanyaan].pertanyaan, listPertanyaanBab3[urutanPertanyaan].jawaban);
            }
            else if (bab == 4)
            {
                SpawnBenarSalah(listPertanyaanBab4[urutanPertanyaan].pertanyaan, listPertanyaanBab4[urutanPertanyaan].jawaban);
            }
            else if (bab == 5)
            {
                SpawnBenarSalah(listPertanyaanBab5[urutanPertanyaan].pertanyaan, listPertanyaanBab5[urutanPertanyaan].jawaban);
            }
            else if (bab == 6)
            {
                SpawnBenarSalah(listPertanyaanBab6[urutanPertanyaan].pertanyaan, listPertanyaanBab6[urutanPertanyaan].jawaban);
            }
            else if (bab == 7)
            {
                SpawnBenarSalah(listPertanyaanBab7[urutanPertanyaan].pertanyaan, listPertanyaanBab7[urutanPertanyaan].jawaban);
            }
            else if (bab == 8)
            {
                SpawnBenarSalah(listPertanyaanBab8[urutanPertanyaan].pertanyaan, listPertanyaanBab8[urutanPertanyaan].jawaban);
            }
            else if (bab == 9)
            {
                SpawnBenarSalah(listPertanyaanBab9[urutanPertanyaan].pertanyaan, listPertanyaanBab9[urutanPertanyaan].jawaban);
            }
            else if (bab == 10)
            {
                SpawnBenarSalah(listPertanyaanBab10[urutanPertanyaan].pertanyaan, listPertanyaanBab10[urutanPertanyaan].jawaban);
            }
        }

    }

    public void SpawnBenarSalah(string soal, string jawaban)
    {
        GameObject pilihanGanda = Instantiate(benarSalahPrefab, spawnSoal);
        pilihanGanda.GetComponent<BenarSalah>().SpawnBenarSalah(soal, jawaban);
    }

    public void StartAwalBS()
    {
        NextPertanyaan(0);
        bgBenarSalah.SetTrigger("Start");
    }

    public void TransisiNext(string hasil)
    {
        if (hasil == "Benar")
        {
            transisiNext.SetTrigger("Benar");

            StartCoroutine(CoroutineA());
            IEnumerator CoroutineA()
            {
                yield return new WaitForSeconds(1);
                AudioManager.instance.SfxBenarBS();
            }
        }
        else
        {
            transisiNext.SetTrigger("Salah");

            StartCoroutine(CoroutineA());
            IEnumerator CoroutineA()
            {
                yield return new WaitForSeconds(1);
                AudioManager.instance.SfxSalahBS();
            }
        }
    }
}
