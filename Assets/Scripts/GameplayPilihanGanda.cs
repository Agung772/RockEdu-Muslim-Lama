using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameplayPilihanGanda : MonoBehaviour
{
    public static GameplayPilihanGanda instance;

    public int bab;
    public int urutanPertanyaan, benar, salah;

    public Text totalPertanyaanText;
    public GameObject pilihanGandaPrefab;
    public Transform spawnSoal;


    [Serializable]
    public struct ListPertanyaan
    {
        public string pertanyaan;
        public string a, b, c;
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


    private void Awake()
    {
        instance = this;

        print(listPertanyaanBab1.Count / 2);


    }

    private void Start()
    {
        bab = SaveManager.instance.GameSave.bab;

        NextPertanyaan();
    }
    //Memunculkan pertanyaan berdasarkan bab
    public void NextPertanyaan()
    {
        //Pertanyaan sudah habis 
        //Saving score
        if (urutanPertanyaan == listPertanyaanBab1.Count - 1)
        {
            if (benar == 0)
            {
                ButtonManager.instance.SpawnScoreUI(0);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScorePilihanGanda, 0);
            }
            else if (benar < listPertanyaanBab1.Count / 2)
            {
                ButtonManager.instance.SpawnScoreUI(1);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScorePilihanGanda, 1);
            }
            else if (benar < listPertanyaanBab1.Count - 2)
            {
                ButtonManager.instance.SpawnScoreUI(2);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScorePilihanGanda, 2);
            }
            else if (benar == listPertanyaanBab1.Count - 1)
            {
                ButtonManager.instance.SpawnScoreUI(3);
                SaveManager.instance.GameSave.SaveScoreMiniGame(SaveManager.instance.GameSave._ScorePilihanGanda, 3);
            }

        }
        //Next pertanyaan
        else
        {

            if (spawnSoal.childCount != 0)
            {
                Destroy(spawnSoal.GetChild(0).gameObject);
            }

            urutanPertanyaan++;
            totalPertanyaanText.text = urutanPertanyaan + "/" + (listPertanyaanBab1.Count - 1);

            if (bab == 1)
            {
                SpawnPilihanGanda(listPertanyaanBab1[urutanPertanyaan].pertanyaan,
                    listPertanyaanBab1[urutanPertanyaan].a, listPertanyaanBab1[urutanPertanyaan].b, listPertanyaanBab1[urutanPertanyaan].c);
            }
            else if (bab == 2)
            {
                SpawnPilihanGanda(listPertanyaanBab2[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab2[urutanPertanyaan].a, listPertanyaanBab2[urutanPertanyaan].b, listPertanyaanBab2[urutanPertanyaan].c);
            }
            else if (bab == 3)
            {
                SpawnPilihanGanda(listPertanyaanBab3[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab3[urutanPertanyaan].a, listPertanyaanBab3[urutanPertanyaan].b, listPertanyaanBab3[urutanPertanyaan].c);
            }
            else if (bab == 4)
            {
                SpawnPilihanGanda(listPertanyaanBab4[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab4[urutanPertanyaan].a, listPertanyaanBab4[urutanPertanyaan].b, listPertanyaanBab4[urutanPertanyaan].c);
            }
            else if (bab == 5)
            {
                SpawnPilihanGanda(listPertanyaanBab5[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab5[urutanPertanyaan].a, listPertanyaanBab5[urutanPertanyaan].b, listPertanyaanBab5[urutanPertanyaan].c);
            }
            else if (bab == 6)
            {
                SpawnPilihanGanda(listPertanyaanBab6[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab6[urutanPertanyaan].a, listPertanyaanBab6[urutanPertanyaan].b, listPertanyaanBab6[urutanPertanyaan].c);
            }
            else if (bab == 7)
            {
                SpawnPilihanGanda(listPertanyaanBab7[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab7[urutanPertanyaan].a, listPertanyaanBab7[urutanPertanyaan].b, listPertanyaanBab7[urutanPertanyaan].c);
            }
            else if (bab == 8)
            {
                SpawnPilihanGanda(listPertanyaanBab8[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab8[urutanPertanyaan].a, listPertanyaanBab8[urutanPertanyaan].b, listPertanyaanBab8[urutanPertanyaan].c);
            }
            else if (bab == 9)
            {
                SpawnPilihanGanda(listPertanyaanBab9[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab9[urutanPertanyaan].a, listPertanyaanBab9[urutanPertanyaan].b, listPertanyaanBab9[urutanPertanyaan].c);
            }
            else if (bab == 10)
            {
                SpawnPilihanGanda(listPertanyaanBab10[urutanPertanyaan].pertanyaan,
                   listPertanyaanBab10[urutanPertanyaan].a, listPertanyaanBab10[urutanPertanyaan].b, listPertanyaanBab10[urutanPertanyaan].c);
            }

        }

    }

    public void SpawnPilihanGanda(string soal, string jawabanA, string jawabanB, string jawabanC)
    {
        GameObject pilihanGanda = Instantiate(pilihanGandaPrefab, spawnSoal);
        pilihanGanda.GetComponent<PilihanGanda>().SpawnPilihanGanda(soal, jawabanA, jawabanB, jawabanC);
    }
}
