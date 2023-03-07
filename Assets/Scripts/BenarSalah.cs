using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BenarSalah : MonoBehaviour
{
    public bool sudahDijawab;
    public string jawabanYangBenar;
    public Text soalText;

    public Image overlayImage, benarImage, salahImage, textBenar, textSalah;

    private void Start()
    {
        benarImage.color = InputColor.instance.green;
        salahImage.color = InputColor.instance.red;
    }

    public void SpawnBenarSalah(string soal, string jawaban)
    {
        soalText.text = soal;
        jawabanYangBenar = jawaban;
    }

    public void ClickButton(GameObject button)
    {
        if (sudahDijawab) return;

        if (!button.GetComponent<ButtonScript>().hasClick)
        {
            benarImage.color = InputColor.instance.green;
            salahImage.color = InputColor.instance.red;

            benarImage.gameObject.GetComponent<ButtonScript>().hasClick = false;
            salahImage.gameObject.GetComponent<ButtonScript>().hasClick = false;

            button.GetComponent<ButtonScript>().hasClick = true;
            button.GetComponent<Image>().color = InputColor.instance.blue;
        }

        //Benar salah jawaban
        else
        {
            if (button.GetComponent<ButtonScript>().jawaban == jawabanYangBenar)
            {
                overlayImage.gameObject.SetActive(true);
                overlayImage.color = InputColor.instance.greenTransparant;
                textBenar.gameObject.SetActive(true);
                GameplayBenarSalah.instance.benar++;
            }
            else
            {
                overlayImage.gameObject.SetActive(true);
                overlayImage.color = InputColor.instance.redTranparant;
                textSalah.gameObject.SetActive(true);
                GameplayBenarSalah.instance.salah++;
            }

            sudahDijawab = true;
            ButtonManager.instance.nextPertanyaanBenarSalah = true;


            //Next pertanyaan
            /*
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(2);
                GameplayBenarSalah.instance.NextPertanyaan();
            }
            */
        }

    }
}
