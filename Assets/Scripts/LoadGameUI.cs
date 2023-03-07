using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameUI : MonoBehaviour
{
    public Text jumlahSaveText;
    int jumlahSave;
    public GameObject LoadButtonContent;

    private void OnEnable()
    {
        JumlahSave();
    }
    public void JumlahSave()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.01f);
            jumlahSave = 0;
            for (int i = 0; i < LoadButtonContent.transform.childCount; i++)
            {
                if (LoadButtonContent.transform.GetChild(i).GetComponent<LoadButton>().nama != "")
                {
                    jumlahSave++;
                }
            }

            if (jumlahSave > 0)
            {
                jumlahSaveText.text = "Ada " + jumlahSave + " dari 4 profil yang disimpan ";
            }
            else
            {
                jumlahSaveText.text = "Belom ada profil yang disimpan";
            }
        }


    }

}
