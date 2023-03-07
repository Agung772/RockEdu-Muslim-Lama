using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMemorize : MonoBehaviour
{
    public static GameplayMemorize instance;
    public string select1, select2;
    public KartuController[] kartuController;

    private void Awake()
    {
        instance = this;

        kartuController = FindObjectsOfType<KartuController>();
        RandomColor();
    }

    void RandomColor()
    {
        for (int i = 0; i < kartuController.Length; i++)
        {
            if (i < 2)
            {
                kartuController[i].color = "red";
            }
            else if (i < 4)
            {
                kartuController[i].color = "yellow";
            }
            else if (i < 6)
            {
                kartuController[i].color = "blue";
            }
        }
    }
    public void SelectCard(string color)
    {
        if (select1 == "")
        {
            select1 = color;
        }
        else if (select2 == "")
        {
            select2 = color;

            CheckColor();
        }
        else
        {
            print("Maksimal 2 cuy");
        }
    }

    void CheckColor()
    {
        //Kalo benar
        if (select1 == select2)
        {
            for (int i = 0; i < kartuController.Length; i++)
            {
                if (kartuController[i].flip)
                {
                    kartuController[i].clear = true;
                }
                
            }
            select1 = "";
            select2 = "";
        }
        //Kalo salah
        else
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(1);
                for (int i = 0; i < kartuController.Length; i++)
                {
                    if (kartuController[i].flip && !kartuController[i].clear)
                    {
                        kartuController[i].FlipBack();
                    }

                }
                select1 = "";
                select2 = "";
            }

        }
    }
}
