using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMystic : Ally, IDroppable
{
    [SerializeField] private GameObject potionToDrop;

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

    // DropIem() from Interface IDroppable
    public void DropItem()
    {
        Instantiate(potionToDrop, dropPoint.position, Quaternion.identity);
        hasDropped = true;
    }

    //Override from Class Ally
    public override void BehaviorToPlayer()
    {
        DropItem();
    }
}
