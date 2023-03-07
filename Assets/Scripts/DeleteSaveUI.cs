using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSaveUI : MonoBehaviour
{
    [HideInInspector]
    public int codeSave;
    [HideInInspector]
    public LoadButton loadButton;
    public void YesButton()
    {
        SaveManager.instance.gameObject.transform.GetChild(codeSave).GetComponent<GameSave>().DeleteSave();
        transform.parent.gameObject.GetComponent<LoadGameUI>().JumlahSave();
        loadButton.LoadTextUI();
        loadButton.nama = "";
        gameObject.SetActive(false);
    }

    public void NoButton()
    {
        gameObject.SetActive(false);
    }
}
