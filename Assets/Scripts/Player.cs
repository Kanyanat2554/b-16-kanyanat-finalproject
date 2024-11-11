using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IShootable
{
    // movement
    Rigidbody2D r2d;
    Animator animator;

    public float maxSpeed = 18f;
    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 1200.0f;


    void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 1.0f;
        BulletSpeed = 5.0f;
        r2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("idle");
            r2d.AddForce(new Vector2(0, jumpForce));
        }

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        Shoot();
    }

    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //animator.SetBool("Ground", grounded);

        //animator.SetFloat("isJump", r2d.velocity.y);
        float move = Input.GetAxis("Horizontal");


        //animator.SetFloat("isRun", Mathf.Abs(move));

        r2d.velocity = new Vector2(move * maxSpeed, r2d.velocity.y);



        IsDead();

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



    // เก็บ Gem
    public int waterGemCollected = 0;
    public int fireGemCollected = 0;// จำนวน Gem ที่ Player เก็บ
    public int waterGemRequirement = 3;
    public int fireGemRequirement = 5; // จำนวน Gem ที่ต้องการในการใช้ Spell
    public bool facingRight = true;
    protected IShootable shooter;
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform SpawnPoint { get; set; }  // Spell Prefab ที่จะพ่นออกมา

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public float BulletSpeed { get; set; }

    public void CollectWaterGem(WaterGem waterGem)
    {
        waterGemCollected += waterGem.gemValue; // เพิ่มจำนวน Gem ที่เก็บ
        Debug.Log("Water Gems collected: " + waterGemCollected);
    }

    public void CollectFireGem(FireGem fireGem)
    {
        fireGemCollected += fireGem.gemValue; // เพิ่มจำนวน Gem ที่เก็บ
        Debug.Log("Fire Gems collected: " + fireGemCollected);
    }
    public void AddHealth(int amount)
    {
        CurrentHp += amount;
        Debug.Log("Current Health: " + CurrentHp);
    }

    public void Shoot()
    {
        if ((fireGemCollected >= fireGemRequirement) || (waterGemCollected >= waterGemRequirement))
        {

            if (Input.GetButtonDown("Fire1"))
            {

                GameObject bullet = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
                Spell spell = bullet.GetComponent<Spell>();

                //spell.SetSpeed(BulletSpeed); // ตั้งค่าความเร็วให้กระสุน

                spell.Init(30, this);

                waterGemCollected -= 3;

                Debug.Log("Water Spell Casted!");
            }
            if (Input.GetButtonDown("Fire2"))
            {

                GameObject bullet = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
                Spell spell = bullet.GetComponent<Spell>();

                //spell.SetSpeed(BulletSpeed); // ตั้งค่าความเร็วให้กระสุน

                spell.Init(50, this);

                fireGemCollected -= 5;

                Debug.Log("Fire Spell Casted!");
            }
        }
    }






}
