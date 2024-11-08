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

    public Animator anim;
    public Rigidbody2D rb;

    //Method
    public bool IsDead()
    {
        if (currentHp <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }

    
    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;
<<<<<<< HEAD
=======
        IsDead();
        
    }

    public bool IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }
    
    public virtual void Init(int newCurrentHealth)
    {
        CurrentHp = newCurrentHealth;
>>>>>>> 175c4a3d46c0633d7e24c2e1b3f42732b86e5a80
        
        IsDead();
    }

    public virtual void Init(int newCurrentHealth)
    {
        CurrentHp = newCurrentHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
<<<<<<< HEAD

    
=======
>>>>>>> 175c4a3d46c0633d7e24c2e1b3f42732b86e5a80
}
