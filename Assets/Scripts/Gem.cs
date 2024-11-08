using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public string itemName; // ชื่อของ item (หากต้องการ)
    public int itemValue;   // ค่าของ item หากต้องการใช้สะสม

    // ฟังก์ชันที่ทำให้ item หายไปเมื่อ Player เก็บ
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าผู้ที่ชนคือ Player หรือไม่
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.CollectItem(this);  // เรียกฟังก์ชันใน Player เพื่อสะสม item
            Destroy(gameObject);       // ทำลาย object นี้หลังจากเก็บ
        }
    }
}
