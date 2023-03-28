using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MiniGame : MonoBehaviour
{

    public enum NamaMiniGame
    {
        ConnectingTheDot,
        SpellingBee,
        PilihanGanda,
        BenarSalah,
    }

    public NamaMiniGame namaMiniGame;
    public GameObject 
        minigameFixed,
        minigameUnfixed,
        buletFixed,
        buletUnfixed;

    public Transform point;

    public GameObject textCanva;
    Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerControllerMGPF>().transform;

        //Load data minigame untuk object minigamnnya
        string namaScoreMinigame = "";

        if (namaMiniGame == NamaMiniGame.ConnectingTheDot) { namaScoreMinigame = SaveManager.instance.GameSave._ScoreConnectingTheDot; }
        else if (namaMiniGame == NamaMiniGame.SpellingBee) { namaScoreMinigame = SaveManager.instance.GameSave._ScoreSpellingBee; }
        else if (namaMiniGame == NamaMiniGame.PilihanGanda) { namaScoreMinigame = SaveManager.instance.GameSave._ScorePilihanGanda; }
        else if (namaMiniGame == NamaMiniGame.BenarSalah) { namaScoreMinigame = SaveManager.instance.GameSave._ScoreBenarSalah; }

        int scoreMinigame = PlayerPrefs.GetInt(namaScoreMinigame + SaveManager.instance.GameSave.bab + SaveManager.instance.GameSave.codeSave);
        print(scoreMinigame);

        textCanva.transform.GetChild(1).gameObject.transform.GetChild(scoreMinigame).gameObject.SetActive(true);


        if (scoreMinigame > 1)
        {
            minigameFixed.SetActive(true);
            minigameUnfixed.SetActive(false);
            buletFixed.SetActive(true);
            buletUnfixed.SetActive(false);
        }
        else
        {
            minigameFixed.SetActive(false);
            minigameUnfixed.SetActive(true);
            buletFixed.SetActive(false);
            buletUnfixed.SetActive(true);
        }

        textCanva.transform.GetChild(0).gameObject.SetActive(false);
        textCanva.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, point.position) < 1.5f)
        {
            textCanva.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Tekan Tombol Benarkan mesin";
            ButtonInteract.instance.gameObject.SetActive(true);
            ButtonInteract.instance.SceneMiniGame(namaMiniGame.ToString());

            textCanva.transform.GetChild(0).gameObject.SetActive(true);
            textCanva.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (Vector3.Distance(player.position, point.position) < 3f)
        {
            ButtonInteract.instance.gameObject.SetActive(false);

            textCanva.transform.GetChild(0).gameObject.SetActive(false);
            textCanva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }



    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textCanva.SetActive(true);
            textCanva.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Tekan Tombol dibawah untuk masuk ke game " + namaText;
            ButtonInteract.instance.gameObject.SetActive(true);
            ButtonInteract.instance.SceneMiniGame(namaMiniGame.ToString());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textCanva.SetActive(false);
            ButtonInteract.instance.gameObject.SetActive(false);
        }
    }
    */
}
