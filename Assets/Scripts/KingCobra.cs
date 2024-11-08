using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCobra : Monster, IShootable
{
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }

    public Player player;

    [field: SerializeField] public Transform SpawnPoint { get; set; }
    [field: SerializeField] public GameObject Bullet { get; set; }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 3.0f;
        DamageHit = 30;
        AttackRange = 6;
        player = GameObject.FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        Behavior();
    }

    // override abstract method
    public override void Behavior()
    {
        Vector2 distance = player.transform.position - transform.position;


        if (distance.magnitude <= attackRange)
        {
            Shoot();
        }
    }

    // method
    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Poison poison = obj.GetComponent<Poison>();
            poison.Init(30, this);
            //GetComponent Script Rock from obj (bullet)
            //initialize Rock's attributes

            WaitTime = 0;
        }

    }
}
