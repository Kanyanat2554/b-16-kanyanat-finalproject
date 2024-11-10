using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBee : Monster
{

    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;

    private Player player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Init(50);
        DamageHit = 10;
        player = GameObject.FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    // override abstract method
    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);


        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FlipCharacter();
        }


        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            FlipCharacter();
        }
    }

    // method
    private void FlipCharacter()
    {
        velocity *= -1;


        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log($"{other}");
            player.TakeDamage(DamageHit);       
        }
    }
}
