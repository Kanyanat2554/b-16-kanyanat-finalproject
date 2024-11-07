using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{


    /*private float attackSpeed;
    public float AttackSpeed { get; set; }

    private float attackRange;
    public float AttackRange {  get; set; }

    public void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * movementSpeed * Time.fixedDeltaTime;
        transform.Translate(movement);
    }
    private void FixedUpdate()
    {
        if (!IsDead())
        {
            Move();
        }
    }*/

    private int attackSpeed;
    private float attackRange;
    private Dictionary<string, int> gems = new Dictionary<string, int>
    {
        { "Water", 0 }, { "Fire", 0 }, { "Wind", 0 }, { "Earth", 0 }
    };

    private Dictionary<string, int> spellCosts = new Dictionary<string, int>
    {
        { "Water", 2 }, { "Fire", 4 }, { "Wind", 1 }, { "Earth", 3 }
    };

    private Dictionary<string, int> spellDamage = new Dictionary<string, int>
    {
        { "Water", 20 }, { "Fire", 30 }, { "Wind", 15 }, { "Earth", 25 }
    };

    public Player()
    {
        MaxHP = 100;
        HP = MaxHP;
        attackSpeed = 5;
        attackRange = 1.5f;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (HP == 0)
        {
            // Reset position to starting point
            transform.position = new Vector2(0, 0);
        }
    }

    public void CollectGem(string gemType, int amount)
    {
        if (gems.ContainsKey(gemType))
        {
            gems[gemType] += amount;
        }
    }

    public void Attack()
    {
        Debug.Log("Player basic attack");
    }

    public void Attack(string spellType)
    {
        if (gems[spellType] >= spellCosts[spellType])
        {
            gems[spellType] -= spellCosts[spellType];
            Debug.Log($"Player casts {spellType} spell with {spellDamage[spellType]} damage");
        }
        else
        {
            Debug.Log("Not enough gems to cast spell");
        }
    }

    protected override void Die()
    {
        Debug.Log("Player has died. Restarting...");
    }
}
