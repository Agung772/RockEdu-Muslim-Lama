using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMetaGame : MonoBehaviour
{
    public PlayerControllerMGPF playerControllerMGPF;
    private void OnMouseDown()
    {
        playerControllerMGPF.MouseDown();
    }
    private void OnMouseUp()
    {
        playerControllerMGPF.MouseUp();
    }
}
