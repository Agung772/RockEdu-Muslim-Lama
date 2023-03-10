using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    public int codeSave;
    public string nama;
    public string urutanSave;

    public GameObject 
        dataProfil, 
        slotKosong;

    public Text 
        namaPlayer, 
        kelas,
        totalBintang,
        waktuSave;

    public Button button;
    public DeleteSaveUI deleteSaveUI;

    private void Start()
    {


        LoadTextUI();
    }

    public void LoadTextUI()
    {
        if (codeSave == 0)
        {
            if (SaveManager.instance.gameObject.transform.GetChild(0).GetComponent<GameSave>().namaPlayer != "")
            {
                LoadText(0);

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
                dataProfil.SetActive(false);
                slotKosong.SetActive(true);
            }

        }
        else if (codeSave == 1)
        {
            if (SaveManager.instance.gameObject.transform.GetChild(1).GetComponent<GameSave>().namaPlayer != "")
            {
                LoadText(1);

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
                dataProfil.SetActive(false);
                slotKosong.SetActive(true);
            }
        }
        else if (codeSave == 2)
        {
            if (SaveManager.instance.gameObject.transform.GetChild(2).GetComponent<GameSave>().namaPlayer != "")
            {
                LoadText(2);

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
                dataProfil.SetActive(false);
                slotKosong.SetActive(true);
            }
        }
        else if (codeSave == 3)
        {
            if (SaveManager.instance.gameObject.transform.GetChild(3).GetComponent<GameSave>().namaPlayer != "")
            {
                LoadText(3);

                button.interactable = true;
            }
            else
            {
                button.interactable = false;
                dataProfil.SetActive(false);
                slotKosong.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Code save belom di ditambah di Load Button");
        }
    }

    void LoadText(int codeSave)
    {
        //Mengambil semua data
        int tempTotalSeluruh = 0;
        for (int i = 0; i < 11; i++)
        {
            if (i != 0)
            {
                int scoreConnectingTheDot = PlayerPrefs.GetInt(SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>()._ScoreConnectingTheDot + i + codeSave);
                int scoreSpellingBee = PlayerPrefs.GetInt(SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>()._ScoreSpellingBee + i + codeSave);
                int scoreBenarSalah = PlayerPrefs.GetInt(SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>()._ScoreBenarSalah + i + codeSave);
                int scorePilihanGanda = PlayerPrefs.GetInt(SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>()._ScorePilihanGanda + i + codeSave);


                int tempTotalBab = scoreConnectingTheDot + scoreSpellingBee + scoreBenarSalah + scorePilihanGanda;
                //print("Di bab " + i + " total bintangnya : " + tempTotalBab);
                tempTotalSeluruh += tempTotalBab;
            }

        }
        print("Total bintang dari " + codeSave + " seluruh bab : " + tempTotalSeluruh);

        //Load text
        dataProfil.SetActive(true);
        slotKosong.SetActive(false);
        namaPlayer.text = SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>().namaPlayer;
        kelas.text = SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>().kelas;
        totalBintang.text = "" + tempTotalSeluruh;
        waktuSave.text = SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>().waktuSave;
        nama = SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>().namaPlayer;

    }

    public void DeleteSave()
    {
        deleteSaveUI.gameObject.SetActive(true);
        deleteSaveUI.codeSave = codeSave;
        deleteSaveUI.loadButton = this;

        //transform.parent.GetComponent<UrutkanLoadButton>().UrutkanLoad();
    }

}
