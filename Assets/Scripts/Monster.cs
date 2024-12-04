using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : Character
{
    [SerializeField] int damageHit;
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
        BehaviorAttackPlayer();
    }

    // abstract method
    public abstract void BehaviorAttackPlayer();
}
