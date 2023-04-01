using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BenarSalah : MonoBehaviour
{
    public bool sudahDijawab;
    public string jawabanYangBenar;
    public string condition;
    public TextMeshProUGUI soalText;
    public TextMeshProUGUI totalPertanyaanText;

    public Image benarImage, salahImage;


    private IEnumerator Start()
    {

        benarImage.GetComponent<Button>().interactable = false;
        salahImage.GetComponent<Button>().interactable = false;

        totalPertanyaanText.text = GameplayBenarSalah.instance.urutanPertanyaan + "/" + 5;

        yield return new WaitForSeconds(1.5f);

        benarImage.GetComponent<Button>().interactable = true;
        salahImage.GetComponent<Button>().interactable = true;

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
            benarImage.color = InputColor.instance.hijauBS;
            salahImage.color = InputColor.instance.merahBS;

            benarImage.gameObject.GetComponent<ButtonScript>().hasClick = false;
            salahImage.gameObject.GetComponent<ButtonScript>().hasClick = false;

            button.GetComponent<ButtonScript>().hasClick = true;
            button.GetComponent<Image>().color = InputColor.instance.biruBS;
        }

        //Benar salah jawaban
        else
        {
            if (button.GetComponent<ButtonScript>().jawaban == jawabanYangBenar)
            {
                GameplayBenarSalah.instance.benar++;
                condition = "Benar";
            }
            else
            {
                GameplayBenarSalah.instance.salah++;
                condition = "Salah";
            }

            sudahDijawab = true;
            ButtonManager.instance.nextPertanyaanBenarSalah = true;
            ButtonManager.instance.nextPertanyaanBS.interactable = true;


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

        AudioManager.instance.SfxClickBS();

    }
}
