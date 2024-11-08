using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Weapon
{
    private Rigidbody2D rb2d;
    private Vector2 force;

    // start
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Damage = 20;
        force = new Vector2(GetShootDirection() * 5, 4);
        Move();
    }

    // override abstract methods
    public override void Move()
    {
        //Debug.Log("Rock move with Rigidbody:force");
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }
}
