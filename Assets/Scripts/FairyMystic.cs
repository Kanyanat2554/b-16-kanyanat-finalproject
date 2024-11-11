using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMystic : Ally
{
    public GameObject itemsToDrop; // ไอเท็มที่ NPC จะดรอป
    public float dropRadius = 3f; // ระยะที่ Player ต้องเข้าใกล้ถึงจะดรอปไอเท็ม
    private bool hasDropped = false;
    private Transform player;
    public Transform dropPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // หา Player จาก Tag
    }

    private void Update()
    {
        if (!hasDropped && Vector3.Distance(transform.position, player.position) <= dropRadius)
        {
            DropItem(); // ดรอปไอเท็มเมื่อ Player เข้ามาในระยะ
        }
    }

    private void DropItem()
    {
        Instantiate(itemsToDrop, dropPoint.position, Quaternion.identity); // สร้างไอเท็มที่ตำแหน่งของ NPC
        hasDropped = true;
    }
}
