using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMystic : Ally, IDroppable
{
    public GameObject potionToDrop;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!hasDropped && Vector3.Distance(transform.position, player.position) <= dropRadius)
        {
            BehaviorToPlayer();
        }
    }

    public void DropItem()
    {
        Instantiate(potionToDrop, dropPoint.position, Quaternion.identity);
        hasDropped = true;
    }

    public override void BehaviorToPlayer()
    {
        DropItem();
    }
}
