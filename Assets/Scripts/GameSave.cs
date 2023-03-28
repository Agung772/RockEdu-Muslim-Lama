using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public int codeSave;


    public string namaPlayer;
    public string karakter;
    public string kelas;

    public string waktuSave;
    public int waktuSaveInt;

    public int bab;

    public int scoreConnectingTheDot;
    public int scoreSpellingBee;
    public int scoreBenarSalah;
    public int scorePilihanGanda;

    public int totalScore;

    public Vector3 posisiPlayer;

    [Space]
    [Space]
    [Space]
    //Anti typo

    public string _NamaPlayer = "NamaPlayer";
    public string _Karakter = "Karakter";
    public string _Kelas = "Kelas";

    public string _WaktuSave = "WaktuSave";

    public string _Bab = "Bab";

    public string _ScoreConnectingTheDot = "ScoreConnectingTheDot";
    public string _ScoreSpellingBee = "ScoreSpellingBee";
    public string _ScoreBenarSalah = "ScoreBenarSalah";
    public string _ScorePilihanGanda = "ScorePilihanGanda";

    public string _PosisiPlayerX = "PosisiPlayerX";
    public string _PosisiPlayerY = "PosisiPlayerY";
    public string _PosisiPlayerZ = "PosisiPlayerZ";


    //Type save, Nama savean + Bab + Code save;

    private void Awake()
    {
        LoadGameData();
    }

    public void LoadGameData()
    {

        namaPlayer = PlayerPrefs.GetString(_NamaPlayer + codeSave);
        karakter = PlayerPrefs.GetString(_Karakter + codeSave);
        kelas = PlayerPrefs.GetString(_Kelas + codeSave);

        waktuSave = PlayerPrefs.GetString(_WaktuSave + codeSave);

        bab = PlayerPrefs.GetInt(_Bab + codeSave);

        //print("Berikut profil kamu " + namaPlayer + ", " + jenisKelamin + ", " + kelas);

        scoreConnectingTheDot = PlayerPrefs.GetInt(_ScoreConnectingTheDot + bab + codeSave);
        scoreSpellingBee = PlayerPrefs.GetInt(_ScoreSpellingBee + bab + codeSave);
        scoreBenarSalah = PlayerPrefs.GetInt(_ScoreBenarSalah + bab + codeSave);
        scorePilihanGanda = PlayerPrefs.GetInt(_ScorePilihanGanda + bab + codeSave);

        totalScore = scoreConnectingTheDot + scoreSpellingBee + scoreBenarSalah + scorePilihanGanda;

        //Posisi player
        posisiPlayer = new Vector3 (PlayerPrefs.GetFloat(_PosisiPlayerX + bab + codeSave), PlayerPrefs.GetFloat(_PosisiPlayerY + bab + codeSave), PlayerPrefs.GetFloat(_PosisiPlayerZ + bab + codeSave));
    }

    public void SaveProfil(string nama, string jenisKelamin, string kelas)
    {
        //Membuat uturan save


        PlayerPrefs.SetString(_NamaPlayer + codeSave, nama);
        PlayerPrefs.SetString(_Karakter + codeSave, jenisKelamin);
        PlayerPrefs.SetString(_Kelas + codeSave, kelas);

        PlayerPrefs.SetString(_WaktuSave + codeSave, System.DateTime.Now.ToString());
        

        LoadGameData();
    }
    public void SaveScoreMiniGame(string namaMiniGame, int score)
    {
        int scoreSebelumnya = PlayerPrefs.GetInt(namaMiniGame + bab + codeSave);

        if (score > scoreSebelumnya)
        {
            PlayerPrefs.SetInt(namaMiniGame + bab + codeSave, score);

            LoadGameData();
        }
    }

    public void SaveBab(int Bab)
    {
        PlayerPrefs.SetInt(_Bab + codeSave, Bab);
        print("Bab yang dipilih : " + Bab);
        LoadGameData();
    }

    public void SavePosisiPlayer(Vector3 savePosisiPlayer)
    {
        posisiPlayer = savePosisiPlayer;
        PlayerPrefs.SetFloat(_PosisiPlayerX + bab + codeSave, posisiPlayer.x);
        PlayerPrefs.SetFloat(_PosisiPlayerY + bab + codeSave, posisiPlayer.y);
        PlayerPrefs.SetFloat(_PosisiPlayerZ + bab + codeSave, posisiPlayer.z);
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteKey(_NamaPlayer + codeSave);
        PlayerPrefs.DeleteKey(_Karakter + codeSave);
        PlayerPrefs.DeleteKey(_Kelas + codeSave);

        PlayerPrefs.DeleteKey(_WaktuSave + codeSave);

        PlayerPrefs.DeleteKey(_Bab + codeSave);

        for (int i = 0; i < 11; i++)
        {
            if (i != 0)
            {
                PlayerPrefs.DeleteKey(_ScoreConnectingTheDot + i + codeSave);
                PlayerPrefs.DeleteKey(_ScoreSpellingBee + i + codeSave);
                PlayerPrefs.DeleteKey(_ScoreBenarSalah + i + codeSave);
                PlayerPrefs.DeleteKey(_ScorePilihanGanda + i + codeSave);

                PlayerPrefs.DeleteKey(_PosisiPlayerX + i + codeSave);
                PlayerPrefs.DeleteKey(_PosisiPlayerY + i + codeSave);
                PlayerPrefs.DeleteKey(_PosisiPlayerZ + i + codeSave);
            }
        }

        LoadGameData();

    }
}
