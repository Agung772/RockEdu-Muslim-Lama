using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHurufController : MonoBehaviour
{
    public string codeSlotHuruf;
    public bool slotHurufAktif = true;

    [Space]
    public string codeHuruf;
    public bool use, clear;

    private void Awake()
    {
        if (!slotHurufAktif)
        {
            Destroy(GetComponent<SlotHurufController>());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<HurufController>())
        {
            if (codeSlotHuruf == other.GetComponent<HurufController>().codeHuruf && !use && !other.GetComponent<HurufController>().click && !other.GetComponent<HurufController>().use)
            {
                clear = true;
            }
            else
            {
                //print("Warnanya salah");
            }

            if (other.GetComponent<HurufController>() && !use && !other.GetComponent<HurufController>().click && !other.GetComponent<HurufController>().use)
            {
                use = true;
                other.GetComponent<HurufController>().use = true;

                
                codeHuruf = other.GetComponent<HurufController>().codeHuruf;
                GameplaySpellingBee.instance.CheckHuruf();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<HurufController>().codeHuruf == codeHuruf)
        {
            clear = false;
            use = false;
            codeHuruf = null;
            other.GetComponent<HurufController>().use = false;

            if (other.GetComponent<HurufController>().click)
            {
                GameplaySpellingBee.instance.checkTotal--;
                GameplaySpellingBee.instance.checkTotal = Mathf.Clamp(GameplaySpellingBee.instance.checkTotal, 0, GameplaySpellingBee.instance.slotHurufController.Length);
            }

        }
    }

}
