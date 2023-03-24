using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFalse : MonoBehaviour
{
    public float timeFalse;
    private void OnEnable()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(timeFalse);
            gameObject.SetActive(false);
        }
    }
}
