using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : Character
{
    // field & property
    /*[SerializeField] int damageHit;
    public int DamageHit
    {
        get
        {
            return damageHit;
        }
        set
        {
            damageHit = value;
        }
    }

    private void Start()
    {
        Behavior();
    }

    // abstract method
    public abstract void Behavior();*/

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        // Implement default monster attack
    }
}
