using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    private int attackSpeed;
    private int attackRange;
    private Dictionary<string, int> gems = new Dictionary<string, int> { { "Water", 0 }, { "Fire", 0 } };
    public int waterGemRequirement = 3;
    public int fireGemRequirement = 5;

    public float maxSpeed = 15f;
    bool facingRight = true;

    Rigidbody2D r2d;
    Animator animator;

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 1200.0f;

    public Player()
    {
        MaxHp = 100;
        CurrentHp = MaxHp;
    }

    // Use this for initialization
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
        Shoot();
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

        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

<<<<<<< HEAD
    public void Attack(string spellType)
    {
        if (spellType == "Water" && gems["Water"] >= waterGemRequirement)
        {
            // Cast water spell
            gems["Water"] = 0;
            Debug.Log("Water Spell Cast!");
            // Instantiate water spell prefab
        }
        else if (spellType == "Fire" && gems["Fire"] >= fireGemRequirement)
        {
            // Cast fire spell
            gems["Fire"] = 0;
            Debug.Log("Fire Spell Cast!");
            // Instantiate fire spell prefab
        }
        else
        {
            Debug.Log("Not enough gems!");
        }
    }

    public void CollectGem(string gemType)
    {
        if (gems.ContainsKey(gemType))
        {
            gems[gemType]++;
            Debug.Log($"{gemType} Gem Collected. Total: {gems[gemType]}");
        }
    }

    
=======
>>>>>>> 175c4a3d46c0633d7e24c2e1b3f42732b86e5a80

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform SpawnPoint { get; set; }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public void Shoot()
    {
        // ��ԡ�������� >> shoot
        if (Input.GetButtonDown("Fire1") && (WaitTime >= ReloadTime))
        {
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Spell spell = obj.GetComponent<Spell>();
            
            WaitTime = 0;
        }
    }
   

   
}
