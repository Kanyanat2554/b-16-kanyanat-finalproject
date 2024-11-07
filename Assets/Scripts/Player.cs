using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
     

    private float attackSpeed;
    public float AttackSpeed { get; set; }

    private float attackRange;
    public float AttackRange {  get; set; }

    public void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * movementSpeed * Time.fixedDeltaTime;
        transform.Translate(movement);
    }
    private void FixedUpdate()
    {
        if (!IsDead())
        {
            Move();
        }
    }
}
