using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCobra : Monster
{
    public KingCobra()
    {
        MaxHP = 110;
        HP = MaxHP;
        Damage = 20;
    }

    public void Attack()
    {
        Debug.Log("Cobra uses Poison Attack!");
    }


    protected override void Die()
    {
        Destroy(gameObject);
        Debug.Log("Cobra has been destroyed");
    }
}
