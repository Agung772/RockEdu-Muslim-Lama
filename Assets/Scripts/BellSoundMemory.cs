using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BellSoundMemory : MonoBehaviour
{
    public string huruf;
    public GameObject textCanva;

    private void OnMouseDown()
    {
        GameplaySoundMemory.instance.CheckJawaban(huruf);
    }

    public void CallBell()
    {
        GameObject textObject = Instantiate(textCanva, transform);
        textObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = huruf;
        RectTransform rectTransform = textObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector3.up * 2;
        Destroy(textObject, 1);
    }
}
