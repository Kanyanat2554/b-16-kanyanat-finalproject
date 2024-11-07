using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBee : Monster
{
    public KillerBee()
    {
        MaxHP = 50;
        HP = MaxHP;
        Damage = 5;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(Damage);
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
        Debug.Log("Bee has been destroyed");
    }
}
