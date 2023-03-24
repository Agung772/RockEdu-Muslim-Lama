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


    private void Awake()
    {
        instance = this;
    }

    public void TextOpening(string textKedua, string minigame)
    {
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
        else
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
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
            if (AnimasiManager.instance.animasiScreenCTD.gameObject.activeInHierarchy)
            {
                AnimasiManager.instance.AnimasiScreenCTD(false);
            }


            gameObject.SetActive(false);


        }
    }
}
