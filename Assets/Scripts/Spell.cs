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

    
   


