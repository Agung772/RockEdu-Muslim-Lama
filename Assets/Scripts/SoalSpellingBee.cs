using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoalSpellingBee : MonoBehaviour
{
    public int totalHuruf;

    public Sprite soalSprite;
    public Sprite[] hurufSprite;
    
    public HurufManager hurufManager;
    public SlotHurufManager slotHurufManager;
    private void Awake()
    {
        hurufManager.totalHuruf = totalHuruf;
        slotHurufManager.totalSlotHuruf = totalHuruf;
    }

}
