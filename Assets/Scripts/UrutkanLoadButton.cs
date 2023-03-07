using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrutkanLoadButton : MonoBehaviour
{
    public GameObject[] childs;
    public GameObject[] childsTemp;

    int j;
    int k;
    private void OnEnable()
    {
        //UrutkanLoad();
    }

    public void UrutkanLoad()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.01f);
            j = 0;

            childsTemp = new GameObject[childs.Length];

            for (int i = 0; i < childs.Length; i++)
            {
                if (childs[i].GetComponent<LoadButton>().urutanSave != "")
                {
                    childsTemp[int.Parse(childs[i].GetComponent<LoadButton>().urutanSave)] = childs[i];
                    print(int.Parse(childs[i].GetComponent<LoadButton>().urutanSave));
                    //j++;
                }
            }

            for (int i = 0; i < childs.Length; i++)
            {
                if (childs[i].GetComponent<LoadButton>().urutanSave == "")
                {
                    if (childsTemp[i] == null)
                    {
                        childsTemp[i] = childs[j];
                        print(j);

                        j++;
                    }
                    //childsTemp[j] = childs[i];


                }
            }
            /*

            for (int i = 0; i < childs.Length; i++)
            {
                childsTemp[i].transform.SetParent(transform.parent);
            }
            for (int i = 0; i < childs.Length; i++)
            {
                childsTemp[i].transform.SetParent(transform);
            }
            */

            //Urutkan save


        }
    }

}
