using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ally : Character
{
    protected bool hasDropped = false;
    protected float dropRadius = 3f;
    protected Transform player;
    [SerializeField] protected Transform dropPoint;

    public abstract void BehaviorToPlayer();
}
