using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBee : Monster
{

    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;

    

    void Update()
    {
        Move();
    }

    /*public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        //�礵��觻Ѩ�غѹ�����¢ͺ��������Ѻ��ҹ
        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            Flip();
        }

        //�礵��觻Ѩ�غѹ�����¢ͺ�������Ѻ��ҹ
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            Flip();
        }
    }*/

    // Flip() �ӡ�á�Ѻ��ҹ����Ф�
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    public KillerBee()
    {
        MaxHp = 50;
        CurrentHp = MaxHp;
    }

    public void Move()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        //�礵��觻Ѩ�غѹ�����¢ͺ��������Ѻ��ҹ
        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            Flip();
        }

        //�礵��觻Ѩ�غѹ�����¢ͺ�������Ѻ��ҹ
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            Flip();
        }
    }
}
