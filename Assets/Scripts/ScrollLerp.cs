using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLerp : MonoBehaviour
{
    public float posChild;
    public int nomorChild;

    public HorizontalLayoutGroup horizontalLayoutGroup;
    public RectTransform rectTransform;
    public float jarakChild;

    public Text totalHalamanText;
    public GameObject rightButton, leftButton;
    private void Start()
    {
        jarakChild = horizontalLayoutGroup.padding.left + transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;

        ButtonUI();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            LeftButton();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RightButton();
        }

        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(posChild, rectTransform.anchoredPosition.y), 5 * Time.deltaTime);
    }

    public void RightButton()
    {
        if (nomorChild < transform.childCount - 1)
        {
            posChild -= jarakChild;
            nomorChild++;

            ButtonUI();
        }

    }
    public void LeftButton()
    {
        if (nomorChild > 0)
        {
            posChild += jarakChild;
            nomorChild--;

            ButtonUI();
        }

    }

    void ButtonUI()
    {
        if (nomorChild == 0)
        {
            rightButton.SetActive(true);
            leftButton.SetActive(false);
        }
        else if (nomorChild == transform.childCount - 1)
        {
            rightButton.SetActive(false);
            leftButton.SetActive(true);
        }
        else
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
        }

        totalHalamanText.text = (nomorChild + 1) + " / " + transform.childCount;
    }
}
