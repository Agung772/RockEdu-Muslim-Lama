using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimasiButton : MonoBehaviour
{
    RectTransform rectTransform;
    float x, y;

    public void PointerDown()
    {
        rectTransform = GetComponent<RectTransform>();
        x = rectTransform.sizeDelta.x;
        y = rectTransform.sizeDelta.y;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x * 1.2f, rectTransform.sizeDelta.y * 1.2f);
    }
    public void PointerUp()
    {
        rectTransform.sizeDelta = new Vector2(x, y);
    }
}
