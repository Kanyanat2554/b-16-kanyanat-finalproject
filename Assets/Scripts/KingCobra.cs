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

    private float bulletLifeTime = 8.0f;

    void Start()
    {
        Init(110);
        WaitTime = 0.0f;
        ReloadTime = 3.0f;
        DamageHit = 30;
        AttackRange = 45;
        player = GameObject.FindObjectOfType<Player>();

        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        BehaviorAttackPlayer();
    }

    //Override from Class Monster
    public override void BehaviorAttackPlayer()
    {
        Vector2 distance = player.transform.position - transform.position;


        if (distance.magnitude <= attackRange)
        {
            Shoot();
        }
    }

    //Shoot() from Interface IShootable
    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Poison poison = obj.GetComponent<Poison>();
            poison.Init(30, this);

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float direction = transform.localScale.x > 0 ? 1f : -1f;
                rb.velocity = new Vector2(direction * 20f, 0); //
            }

            Destroy(poison, bulletLifeTime);
            WaitTime = 0;
        }
    }
}
