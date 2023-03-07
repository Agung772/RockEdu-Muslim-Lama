using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniGame : MonoBehaviour
{

    public enum NamaMiniGame
    {
        ConnectingTheDot,
        SpellingBee,
        PilihanGanda,
        BenarSalah,
    }

    public string namaText;
    public NamaMiniGame namaMiniGame;
    public GameObject textCanva;
    Transform player;

    private void Start()
    {
        textCanva.SetActive(false);
        player = FindObjectOfType<PlayerControllerMGPF>().transform;
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 3)
        {
            textCanva.SetActive(true);
            textCanva.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Tekan Tombol dibawah untuk masuk ke game " + namaText;
            ButtonInteract.instance.gameObject.SetActive(true);
            ButtonInteract.instance.SceneMiniGame(namaMiniGame.ToString());
        }
        else if (Vector3.Distance(player.position, transform.position) < 3.5f)
        {
            textCanva.SetActive(false);
            ButtonInteract.instance.gameObject.SetActive(false);
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
