using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartuController : MonoBehaviour
{
    public string color;
    public bool flip, clear;

    private void Start()
    {
        ChangeColors();
    }

    public void ChangeColors()
    {
        if (color == "red")
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (color == "blue")
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (color == "yellow")
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else
        {
            print("Isi warna objectnya cuy");
        }

    }

    private void OnMouseDown()
    {
        ClickMouse();
    }

    public void ClickMouse()
    {
        if (clear) return;

        if (GameplayMemorize.instance.select1 == "" || GameplayMemorize.instance.select2 == "")
        {
            flip = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            GameplayMemorize.instance.SelectCard(color);
        }
        else if (flip)
        {
            flip = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GameplayMemorize.instance.select1 = "";
            GameplayMemorize.instance.select2 = "";
        }
        print(gameObject.name);
    }

    public void FlipBack()
    {
        flip = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
