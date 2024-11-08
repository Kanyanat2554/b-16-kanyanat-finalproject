using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuryBird : Monster
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Init(80);
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    // override abstract method
    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        
        if (rb.position.y <= movePoints[0].position.y && velocity.y < 0)
        {
            ChangeDirection();
        }

        
        else if (rb.position.y >= movePoints[1].position.y && velocity.y > 0)
        {
            ChangeDirection();
        }
    }

    // method
    private void ChangeDirection()
    {
        velocity.y *= -1;
    }
}
