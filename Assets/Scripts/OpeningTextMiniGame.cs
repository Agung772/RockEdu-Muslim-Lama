using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpeningTextMiniGame : MonoBehaviour
{
    public static OpeningTextMiniGame instance;
    public TextMeshProUGUI textOpening;
    bool clickTextKedua;

    public GameObject loadingPG;
    public GameObject bgOpening;

    public Animator screenCTD;
    string miniGame;

    private void Awake()
    {
        instance = this;
    }

    public void TextOpening(string textKedua, string minigame)
    {
        miniGame = minigame;
        if (minigame == "PG")
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                loadingPG.SetActive(true);
                yield return new WaitForSeconds(5);
                loadingPG.SetActive(false);

                textOpening.gameObject.SetActive(true);

                yield return new WaitForSeconds(2);
                textOpening.text = textKedua;
                clickTextKedua = true;
            }

        }
        else if (minigame == "BS")
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                textOpening.gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                textOpening.text = textKedua;
                clickTextKedua = true;
            }
        }
        else if (minigame == "CTD")
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                textOpening.gameObject.SetActive(true);
                screenCTD.gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
                screenCTD.SetTrigger("Open");
                yield return new WaitForSeconds(1);
                yield return new WaitForSeconds(2);
                textOpening.text = textKedua;
                clickTextKedua = true;
            }
        }
        else
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                textOpening.gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                textOpening.text = textKedua;
                clickTextKedua = true;
            }
        }

    }

    private void Update()
    {
        if (Input.anyKeyDown && clickTextKedua)
        {
            if (miniGame == "PG")
            {
                if (AnimasiManager.instance.animasiScreenCTD.gameObject.activeInHierarchy)
                {
                    AnimasiManager.instance.AnimasiScreenCTD(false);
                }
                gameObject.SetActive(false);
                GameplayPilihanGanda.instance.StartAwalPG();
            }
            else if (miniGame == "BS")
            {
                if (AnimasiManager.instance.animasiScreenCTD.gameObject.activeInHierarchy)
                {
                    AnimasiManager.instance.AnimasiScreenCTD(false);
                }
                gameObject.SetActive(false);
                GameplayBenarSalah.instance.StartAwalBS();
            }
            else if (miniGame == "CTD")
            {

                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    screenCTD.SetTrigger("Close");
                    yield return new WaitForSeconds(1);
                    textOpening.gameObject.SetActive(false);
                    bgOpening.SetActive(false);
                    screenCTD.SetTrigger("Open");
                    yield return new WaitForSeconds(1);
                    gameObject.SetActive(false);
                }


                //GameplayBenarSalah.instance.StartAwalBS();
            }
            else
            {
                if (AnimasiManager.instance.animasiScreenCTD.gameObject.activeInHierarchy)
                {
                    AnimasiManager.instance.AnimasiScreenCTD(false);
                }
                gameObject.SetActive(false);
            }




        }

    }
}
