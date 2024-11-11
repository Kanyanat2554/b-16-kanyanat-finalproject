using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpirit : Ally
{
    public GameObject[] itemsToDrop;
    public Transform dropPoint;// รายการ Prefab ของไอเทมที่ NPC สามารถดรอปได้
    public float dropRadius = 3f;     // ระยะที่ Player ต้องเดินผ่าน
    private bool hasDropped = false;  // เช็คว่า NPC ดรอปไอเทมแล้วหรือยัง

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่า object ที่ชนคือ Player และยังไม่ดรอปไอเทม
        if (other.CompareTag("Player") && !hasDropped)
        {
            Debug.Log("Player entered the trigger zone!");
            DropItem();
        }
    }

    void DropItem()
    {
        if (itemsToDrop.Length > 0)
        {
            // สุ่มจำนวนไอเทมที่จะดรอป (ระหว่าง 1 ถึง 9 ชิ้น)
            int numberOfItemsToDrop = Random.Range(1, 10);  // จำนวนที่ดรอปจะสุ่มระหว่าง 1-9

            // ดรอปไอเทมตามจำนวนที่สุ่มได้
            for (int i = 0; i < numberOfItemsToDrop; i++)
            {
                // สุ่มเลือกไอเทมจากรายการ
                int randomIndex = Random.Range(0, itemsToDrop.Length);
                GameObject itemToDrop = itemsToDrop[randomIndex];

                // ตรวจสอบตำแหน่งที่ไอเทมจะดรอป
                Debug.Log("Dropping item at position: " + dropPoint.position);

                // สร้างไอเทมที่ถูกดรอปในตำแหน่งที่กำหนด
                Instantiate(itemToDrop, dropPoint.position, Quaternion.identity);
                Debug.Log("Item Dropped!");
            }

            // กำหนดว่า NPC ดรอปไอเทมแล้ว
            hasDropped = true;
        }
    }


}
