using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int currentHp;
    public int CurrentHp { get; protected set; }

    private int maxHp;
    public int MaxHp { get; protected set; }

    //[SerializeField] private float movementSpeed;
    //public float MovementSpeed { get; set; }

    [SerializeField]  protected Animator anim;
    [SerializeField]  protected Rigidbody2D rb;

    //Method
    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            CurrentHp = 0;

            Debug.Log($"{this.name} took {damage} damage, Remaining Health: {this.CurrentHp}");

            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
    /*public virtual void Init(int newHealth)
    {
        CurrentHp = newHealth;
        
        //get components for prefabs
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }*/
}
