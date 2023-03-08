using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditContent : MonoBehaviour
{
    public float speed;
    float value, aklerasi;
    public bool otomatis;

    public Scrollbar scrollBar;

    private void OnEnable()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            value = 1;
            aklerasi = 0;
            scrollBar.value = value;

            yield return new WaitForSeconds(2);
            otomatis = true;

        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            otomatis = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            otomatis = true;
            value = scrollBar.value;
            aklerasi = 0;
        }

        if (otomatis)
        {
            if (aklerasi <= 1)
            {
                aklerasi += 0.4f * Time.deltaTime;
            }


            if (scrollBar.value <= 0)
            {
                otomatis = false;
            }
            else if (scrollBar.value > 1)
            {
                value -= 1 * Time.deltaTime * aklerasi;
            }
            else
            {
                value -= speed * Time.deltaTime * aklerasi;
            }

            scrollBar.value = value;
        }
    }

    
}
