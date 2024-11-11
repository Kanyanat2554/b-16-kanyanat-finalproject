using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Weapon
{
    public int spellDamage = 35;  // ความเสียหายของ Spell
    public float speed = 6.0f;
    public bool playerFacingRight = true;
    private Rigidbody2D rb;
    private bool isFacingRight;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        float direction = isFacingRight ? 1 : -1;
        rb.velocity = new Vector2(direction * speed, 0);

        // ปรับการหมุนให้กระสุนหันตามทิศทาง
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }
    public override void OnHitWith(Character character)
    {
        if (character is Monster)
        {
            character.TakeDamage(this.Damage);
        }
    }
    public void SetDirection(bool facingRight)
    {
        isFacingRight = facingRight;
    }

    public void SetSpeed(float bulletSpeed)
    {
        speed = bulletSpeed;
    }
}

    
   


