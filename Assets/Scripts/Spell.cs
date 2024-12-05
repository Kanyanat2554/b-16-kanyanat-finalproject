using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Weapon
{
    [SerializeField] private float speed;

    private void Start()
    {
        Damage = 35;
        speed = 6.0f * GetShootDirection();
    }

    // override from Class Weapon
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        Move();
    }

    // override from Class Weapon
    public override void OnHitWith(Character character)
    {
        if (character is Monster)
        {
            character.TakeDamage(this.Damage);
        }
    }
}

    
   


