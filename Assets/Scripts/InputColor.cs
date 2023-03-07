using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputColor : MonoBehaviour
{
    public static InputColor instance;

    public Color red, blue, green, yellow, orange, greenTransparant ,redTranparant, grey, blueButtonPG;

    private void Awake()
    {
        instance = this;
    }
}
