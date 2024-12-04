using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

        winTxt.gameObject.SetActive(false);

        UpdateWaterText();
        UpdateFireText();
    }

    void Update()
    {
        #region This part is from character model pack 
        float move = Input.GetAxis("Horizontal");
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("idle");
            r2d.AddForce(new Vector2(0, jumpForce));
        }
        #endregion

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

        float move = Input.GetAxis("Horizontal");

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

    // à¡çº Gem
    public int waterGemCollected = 0;
    public int fireGemCollected = 0;
    public int waterGemRequirement = 3;
    public int fireGemRequirement = 5;

    public bool facingRight = true;
    protected IShootable shooter;
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform SpawnPoint { get; set; }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public float BulletSpeed { get; set; }

    public void CollectGem(WaterGem waterGem)
    {
        waterGemCollected += waterGem.gemValue; 
        Debug.Log("Water Gems collected: " + waterGemCollected);
        UpdateWaterText();
    }

    public void CollectGem(FireGem fireGem)
    {
        fireGemCollected += fireGem.gemValue;
        Debug.Log("Fire Gems collected: " + fireGemCollected);
        UpdateFireText();
    }
    public void AddHealth(int amount)
    {
        CurrentHp = Mathf.Min(CurrentHp + amount, MaxHp);
        healthBar.updateHealthBar(CurrentHp); 
        Debug.Log("Current Health: " + CurrentHp);
    }
    public void SetMaxHp(int newMaxHp)
    {
        MaxHp = newMaxHp;
        healthBar.SetMaxHealth(MaxHp); 
        if (CurrentHp >= MaxHp)
        {
            CurrentHp = MaxHp;
            healthBar.updateHealthBar(CurrentHp); 
        }
    }

    public void Shoot()
    {
        if ((fireGemCollected >= fireGemRequirement) || (waterGemCollected >= waterGemRequirement))
        {

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
                Spell spell = bullet.GetComponent<Spell>();

                spell.Init(30, this);

                waterGemCollected -= 3;
                if (waterGemCollected <= 0)
                {
                    waterGemCollected = 0;
                }

                UpdateWaterText();

                Debug.Log("Water Spell Casted!");
            }
            if (Input.GetButtonDown("Fire2"))
            {
                GameObject bullet = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
                Spell spell = bullet.GetComponent<Spell>();

                spell.Init(50, this);

                fireGemCollected -= 5;
                if (fireGemCollected <= 0)
                {
                    fireGemCollected = 0;
                }

                UpdateFireText();

                Debug.Log("Fire Spell Casted!");
            }
        }
    }

    [SerializeField] TextMeshProUGUI winTxt, waterTxt, fireTxt;
    [SerializeField] private GameObject winPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject == winPoint)
        {
            ShowWinText();
        }
    }

    private void ShowWinText()
    {
        winTxt.text = ("You Win!!!");
        winTxt.gameObject.SetActive(true);
    }

    void UpdateWaterText()
    {
        waterTxt.text = $"(Left Click) Water Gems: {waterGemCollected}/3";
    }
    void UpdateFireText()
    {
        fireTxt.text = $"(Right Click) Fire Gems: {fireGemCollected}/5";
    }
}
