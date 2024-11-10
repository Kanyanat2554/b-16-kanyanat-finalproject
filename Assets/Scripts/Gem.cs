using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemValue = 1; // กำหนดค่าของ Gem ที่เก็บได้

    // ฟังก์ชันที่ทำให้ Player เก็บ Gem
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.CollectGem(this);  // เรียกฟังก์ชันใน Player เพื่อสะสม Gem
            Destroy(gameObject);      // ทำลาย Gem หลังจากเก็บ
        }
    }
}
