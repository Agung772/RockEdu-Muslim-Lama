using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurufManager : MonoBehaviour
{
    public int totalHuruf;

    public GameObject hurufPrefab;
    public HurufController[] hurufController;

    int urutanHuruf;
    public float startX;

    public int[] randomClue;
    public int maxClue = 1;
    int totalnonClue;

    public float[] posisiXNonClue;

    public Vector3[] positionHuruf;

    int j;
    private void Start()
    {
        startX = -0.75f * (totalHuruf - 1);
        hurufController = new HurufController[totalHuruf];
        positionHuruf = new Vector3[totalHuruf];


        //random clue
        randomClue = new int[totalHuruf];
        for (int i = 0; i < randomClue.Length; i++)
        {
            if (i == 0 || i == totalHuruf - 1)
            {
                randomClue[i] = 1;
            }
            else
            {
                float random = Random.Range(0, 2);
                if (random == 1 && maxClue > 0)
                {
                    maxClue--;
                    randomClue[i] = 1;
                }
                else
                {
                    randomClue[i] = -2;
                    totalnonClue++;
                }
            }
        }

        posisiXNonClue = new float[totalnonClue];

        for (int i = 0; i < totalHuruf; i++)
        {
            Instantiate(hurufPrefab, transform);
            hurufController[i] = transform.GetChild(i).GetComponent<HurufController>();
            urutanHuruf++;
            hurufController[i].codeHuruf = urutanHuruf.ToString();

            //Set posisi huruf
            hurufController[i].transform.localPosition = new Vector3(startX, randomClue[i], 0);
            if (randomClue[i] == -2)
            {
                print(i);
                
                posisiXNonClue[j] = startX;
                j++;
            }


            startX += 1.5f;
        }



        for (int i = 0; i < totalHuruf; i++)
        {
            //Save posisi huruf
            positionHuruf[i] = hurufController[i].transform.localPosition;
        }
    }


    public void RestartHuruf()
    {
        for (int i = 0; i < totalHuruf; i++)
        {
            hurufController[i].transform.localPosition = positionHuruf[i];
        }

    }
}
