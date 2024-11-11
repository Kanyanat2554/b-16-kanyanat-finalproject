using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Weapon
{
    /*public int spellDamage = 35;  // ����������¢ͧ Spell
    public float speed = 6.0f;
    public bool playerFacingRight = true;
    private Rigidbody2D rb;
    private bool isFacingRight;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        float direction = GetShootDirection();
        rb.velocity = new Vector2(direction * speed, 0);

        // ��Ѻ�����ع������ع�ѹ�����ȷҧ
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }
    public override void OnHitWith(Character character)
    {
        if (character is Monster)
        {
            character.TakeDamage(this.Damage);
        }
    }
    

    public void SetSpeed(float bulletSpeed)
    {
        speed = bulletSpeed;
    }*/
    [SerializeField] private float speed;

    private void Start()
    {
        Damage = 35;
        speed = 6.0f * GetShootDirection();
    }

    // override abstract methods
    public override void Move()
    {
        //Debug.Log("Banana moves with constant speed using Transform.");

        // s = v * t
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void OnHitWith(Character character)
    {
        if (character is Monster)
        {
            character.TakeDamage(this.Damage);
        }
    }

}

    
   


