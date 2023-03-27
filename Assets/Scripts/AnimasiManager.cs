using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasiManager : MonoBehaviour
{
    public static AnimasiManager instance;

    public Animator animasiScreenCTD;

    private void Awake()
    {
        instance = this;
    }

    public void AnimasiScreenCTD(bool condition)
    {
        if (!condition)
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(1);
                animasiScreenCTD.SetTrigger("Close");
            }
        }
        else
        {
            animasiScreenCTD.gameObject.SetActive(true);
            animasiScreenCTD.SetTrigger("Open");
        }
    }
}
