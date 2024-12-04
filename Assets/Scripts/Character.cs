using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int currentHp;
    public int CurrentHp { get; protected set; }

    [SerializeField] private int maxHp;
    public int MaxHp { get; protected set; }

    public Animator anim;
    public Rigidbody2D rb;
    public HealthBar healthBar;

    //Method
    public virtual void Init(int newCurrentHealth)
    {
        CurrentHp = newCurrentHealth;
        healthBar.SetMaxHealth(newCurrentHealth);
        maxHp = CurrentHp;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Debug.Log($"({this} has {CurrentHp} left)");
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        healthBar.updateHealthBar(CurrentHp);

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
}
