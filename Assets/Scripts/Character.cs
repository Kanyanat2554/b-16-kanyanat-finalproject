using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int currentHp;
    public int CurrentHp { get; protected set; }

    [SerializeField] private int maxHp;
    public int MaxHp { get; protected set; }

    //[SerializeField] private float movementSpeed;
    //public float MovementSpeed { get; set; }

    public Animator anim;
    public Rigidbody2D rb;

    //Method
    

    
    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;

        IsDead();

        Debug.Log($"({this} has {CurrentHp} left");
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
    
    

    public virtual void Init(int newCurrentHealth)
    {
        CurrentHp = newCurrentHealth;
        maxHp = CurrentHp;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Debug.Log($"({this} has {CurrentHp} left)");
    }
    
}
