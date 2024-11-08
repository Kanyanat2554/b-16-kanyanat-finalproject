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
        this.damage = 30;         // ��駤�Ҥ���������¢ͧ Poison
        this.sourceEnemy = enemy;     // ��駤�� Enemy ����ԧ Poison �͡�� (������������ѧ)
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ǩ�ͺ��� Poison ���Ѻ Player
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            // ���¡��ѧ��ѹ�Ѻ������������ Player
            player.TakeDamage(damage);

            // ����� Poison ��ѧ�ҡ�ӡ������
            Destroy(gameObject);
        }
    }
}
