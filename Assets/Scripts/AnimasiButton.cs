using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimasiButton : MonoBehaviour
{
    RectTransform rectTransform;

    bool start;
    float minX, maxX;
    float minY, maxY;

    public void PointerDown()
    {
        rectTransform = GetComponent<RectTransform>();

        if (!start)
        {
            start = true;

            minX = rectTransform.sizeDelta.x;
            maxX = rectTransform.sizeDelta.x * 1.2f;

            minY = rectTransform.sizeDelta.y;
            maxY = rectTransform.sizeDelta.y * 1.2f;
        }

        rectTransform.sizeDelta = new Vector2(maxX, maxY);
    }
    public void PointerUp()
    {
        rectTransform.sizeDelta = new Vector2(minX, minY);
    }
}
