using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    /*private int currentHp;
    public int CurrentHp { get; protected set; }

    private int maxHp;
    public int MaxHp { get; protected set; }

    private float movementSpeed;
    public float MovementSpeed { get; set; }

    protected Animator anim;
    protected Rigidbody2D rb;

    //Method
    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp < 0) CurrentHp = 0;

        IsDead();
    }

    public bool IsDead()
    {
        if (CurrentHp <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }
    public virtual void Init(int newHealth)
    {
        CurrentHp = newHealth;
        
        //get components for prefabs
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }*/

    public int HP { get; protected set; }
    public int MaxHP { get; protected set; }

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            Die();
        }
    }

    protected abstract void Die();
}
