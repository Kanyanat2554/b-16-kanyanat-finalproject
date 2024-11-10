using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character, IShootable
{
    // movement
    Rigidbody2D r2d;
    Animator animator;

    public float maxSpeed = 18f;
    bool facingRight = true;
    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 1200.0f;


    void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 1.0f;
        r2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Ground", false);
            r2d.AddForce(new Vector2(0, jumpForce));
        }
        if ((gemsCollected >= fireGemRequirement))
        {
            Shoot();
        }

        //Debug.Log($"{this.name} has {CurrentHp}");
    }

    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Ground", grounded);

        animator.SetFloat("vSpeed", r2d.velocity.y);

        float move = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(move));

        r2d.velocity = new Vector2(move * maxSpeed, r2d.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

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
    public int gemsCollected = 0; // จำนวน Gem ที่ Player เก็บ
    public int waterGemRequirement = 3;
    public int fireGemRequirement = 5; // จำนวน Gem ที่ต้องการในการใช้ Spell
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform SpawnPoint { get; set; }  // Spell Prefab ที่จะพ่นออกมา
    
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    public void CollectGem(Gem gem)
    {
        gemsCollected += gem.gemValue; // เพิ่มจำนวน Gem ที่เก็บ
        Debug.Log("Gems collected: " + gemsCollected);

        
    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Spell spell = obj.GetComponent<Spell>();
            spell.Init(45, this);

            gemsCollected -= 5;

            Debug.Log("Spell Casted!");
        }
    }
}
