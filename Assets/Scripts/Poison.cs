using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Weapon
{
    /*private Rigidbody2D rb2d;
    private Vector2 force;

    // start
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Damage = 30;
        //force = new Vector2(GetShootDirection() * 5, 4);
        Move();
    }*/

    // override abstract methods
    public override void Move()
    {
        //Debug.Log("Rock move with Rigidbody:force");
        //rb2d.AddForce(force, ForceMode2D.Impulse);
        
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }

    
    private KingCobra sourceEnemy;

    public void Init(int damage, KingCobra enemy)
    {
        this.damage = 30;         // ตั้งค่าความเสียหายของ Poison
        this.sourceEnemy = enemy;     // ตั้งค่า Enemy ที่ยิง Poison ออกมา (เผื่อใช้ในภายหลัง)
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่า Poison ชนกับ Player
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            // เรียกใช้ฟังก์ชันรับความเสียหายใน Player
            player.TakeDamage(damage);

            // ทำลาย Poison หลังจากทำการโจมตี
            Destroy(gameObject);
        }
    }
}
