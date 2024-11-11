using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    /*[SerializeField] protected int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    protected IShootable shooter;

    // abstract methods
    public abstract void OnHitWith(Character character);
    public abstract void Move();

    // method
    public void Init(int damage, IShootable _owner)
    {
        Damage = damage;
        shooter = _owner;

    }
    public int GetShootDirection()
    {

        Debug.Log("shooter.SpawnPoint.position.x shooter.SpawnPoint.parent.position.x");
        float ShootDir = shooter.SpawnPoint.position.x - shooter.SpawnPoint.parent.position.x;
        Debug.Log($"{ShootDir} shoot shoot");
        if (ShootDir > 0)
        {
            return 1; //right direction
        }
        else return -1; //left direction

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 6f);
    }*/

    [SerializeField] protected int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    protected IShootable shooter;

    // abstract methods
    public abstract void OnHitWith(Character character);
    public abstract void Move();

    // method
    public void Init(int damage, IShootable _owner)
    {
        Damage = damage;
        shooter = _owner;

    }
    public int GetShootDirection()
    {
        Debug.Log(shooter.SpawnPoint.position.x);
        Debug.Log(shooter.SpawnPoint.parent.position.x);
        float ShootDir = shooter.SpawnPoint.position.x - shooter.SpawnPoint.parent.position.x;
        if (ShootDir > 0)
        {
            return 1; //right direction
        }
        else return -1; //left direction

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 6f);
    }
}
