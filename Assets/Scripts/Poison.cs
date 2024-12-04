using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Weapon
{
    public override void Move()
    {
        Debug.Log("Poison is moving");
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }


    private KingCobra sourceEnemy;

    public void Init(int damage, KingCobra enemy)
    {
        this.damage = 30;  // µÑé§¤èÒ¤ÇÒÁàÊÕÂËÒÂ¢Í§ Poison
        this.sourceEnemy = enemy;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
