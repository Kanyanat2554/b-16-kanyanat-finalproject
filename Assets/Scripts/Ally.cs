using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ally : Character
{
    protected bool hasDropped = false;
    protected float dropRadius = 3f;
    protected Transform player; //เก็บข้อมูลตำแหน่งของ Player
    [SerializeField] protected Transform dropPoint;

    // Abstract Method
    public abstract void BehaviorToPlayer();
}
