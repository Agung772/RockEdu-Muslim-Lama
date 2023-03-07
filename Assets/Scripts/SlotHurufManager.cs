using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHurufManager : MonoBehaviour
{
    public int totalSlotHuruf;

    public GameObject slotHurufPrefab;
    public SlotHurufController[] slotHurufController;

    int urutanHuruf;
    public float startX;

    private void Start()
    {
        startX = -0.75f * (totalSlotHuruf - 1);
        slotHurufController = new SlotHurufController[totalSlotHuruf];
        for (int i = 0; i < totalSlotHuruf; i++)
        {
            Instantiate(slotHurufPrefab, transform);
            slotHurufController[i] = transform.GetChild(i).GetComponent<SlotHurufController>();
            urutanHuruf++;
            slotHurufController[i].codeSlotHuruf = urutanHuruf.ToString();

            slotHurufController[i].transform.localPosition = new Vector3(startX, 0, 0);
            startX += 1.5f;
        }
    }
}
