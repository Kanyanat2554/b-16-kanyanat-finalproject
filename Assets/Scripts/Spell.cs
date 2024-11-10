using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Weapon
{
    public int spellDamage = 35;  // ความเสียหายของ Spell
    public float speed = 6f; // ความเร็วของ Spell

    private void Start()
    {
        Move();
    }

    // ฟังก์ชันเมื่อ Spell ชนกับศัตรู
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่า Spell ชนกับศัตรู
        Monster enemy = other.GetComponent<Monster>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // เรียกฟังก์ชันให้ศัตรูรับความเสียหาย
            Destroy(gameObject);      // ทำลาย Spell หลังจากโจมตี
        }
        Debug.Log("Play shoot");
    }

    public override void Move()
    {
        // ตั้งค่าความเร็วในการเคลื่อนที่ของ Spell
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * speed; // เคลื่อนที่ในทิศทางที่กำหนด
        }
    }

    public override void OnHitWith(Character character)
    {
        if (character is Monster)
        {
            character.TakeDamage(this.Damage);
        }
    }
    
}
