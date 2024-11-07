using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuryBird : Monster
{
    public FuryBird()
    {
        MaxHP = 80;
        HP = MaxHP;
        Damage = 15;
    }

    private void Update()
    {
        transform.Translate(new Vector2(Mathf.Sin(Time.time), Mathf.Cos(Time.time)) * Time.deltaTime);
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
        Debug.Log("Hawk has been destroyed");
    }
}
