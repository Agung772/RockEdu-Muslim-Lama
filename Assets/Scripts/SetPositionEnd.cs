using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionEnd : MonoBehaviour
{
    public string codeDot;
    public string condition = "null";
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EndDot>())
        {
            if (other.GetComponent<EndDot>().codeDot == codeDot) condition = "benar";
            else if (other.GetComponent<EndDot>().codeDot != codeDot) condition = "salah";
            else condition = "null";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EndDot>())
        {
            condition = "null";
        }
    }

}
