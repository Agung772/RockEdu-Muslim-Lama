using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    bool optionBool;
    public void SetActiveOption(GameObject option)
    {
        if (!optionBool)
        {
            optionBool = true;
            option.SetActive(true);

            AudioManager.instance.SfxPause();
        }
        else
        {
            optionBool = false;
            option.SetActive(false);

            AudioManager.instance.SfxUnpause();
        }

    }
}
