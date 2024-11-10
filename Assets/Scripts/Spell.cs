using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Weapon
{
    public int spellDamage = 35;  // ����������¢ͧ Spell
    public float speed = 6f; // �������Ǣͧ Spell

    private void Start()
    {
        Move();
    }

    // �ѧ��ѹ����� Spell ���Ѻ�ѵ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ǩ�ͺ��� Spell ���Ѻ�ѵ��
        Monster enemy = other.GetComponent<Monster>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // ���¡�ѧ��ѹ����ѵ���Ѻ�����������
            Destroy(gameObject);      // ����� Spell ��ѧ�ҡ����
        }
        Debug.Log("Play shoot");
    }

    public override void Move()
    {
        // ��駤�Ҥ�������㹡������͹���ͧ Spell
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * speed; // ����͹���㹷�ȷҧ����˹�
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
