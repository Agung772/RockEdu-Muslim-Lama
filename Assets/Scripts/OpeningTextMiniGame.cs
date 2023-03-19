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


    private void Awake()
    {
        instance = this;
    }

    public void TextOpening(string textKedua)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(2);
            textOpening.text = textKedua;
            clickTextKedua = true;
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
