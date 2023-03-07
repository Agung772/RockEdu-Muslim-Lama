using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySoundMemory : MonoBehaviour
{
    public static GameplaySoundMemory instance;
    public BellSoundMemory[] bellSoundMemory;
    public GameObject textCanva;
    public string jawabanYangBenar;
    string textDefault;

    private void Awake()
    {
        instance = this;
        bellSoundMemory = FindObjectsOfType<BellSoundMemory>();
    }
    private void Start()
    {
        StartBell();

        textDefault = textCanva.transform.GetChild(0).gameObject.GetComponent<Text>().text;
    }
    void StartBell()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
            bellSoundMemory[0].CallBell();
            yield return new WaitForSeconds(1);
            bellSoundMemory[1].CallBell();
            yield return new WaitForSeconds(1);
            bellSoundMemory[2].CallBell();
            yield return new WaitForSeconds(1);
            bellSoundMemory[3].CallBell();
            yield return new WaitForSeconds(1);
            bellSoundMemory[4].CallBell();

        }
    }

    public void CheckJawaban(string huruf)
    {
        if (jawabanYangBenar == huruf)
        {
            textCanva.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Jawabannya Benar";
        }
        else
        {
            textCanva.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Jawabannya salah cuy";

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(3);
                textCanva.transform.GetChild(0).gameObject.GetComponent<Text>().text = textDefault;
                yield return new WaitForSeconds(1);
                StartBell();
            }
        }
    }
}
