using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpirit : Ally, IDroppable
{
    public GameObject[] firePotionToDrop;
    public void DropItem()
    {
        if (firePotionToDrop.Length > 0)
        {
            int numberOfItemsToDrop = Random.Range(2, 6);

            for (int i = 0; i < numberOfItemsToDrop; i++)
            {
                int randomIndex = Random.Range(0, firePotionToDrop.Length);
                GameObject itemToDrop = firePotionToDrop[randomIndex];

                Debug.Log("Dropping item at position: " + dropPoint.position);

                Instantiate(itemToDrop, dropPoint.position, Quaternion.identity);
                Debug.Log("Item Dropped!");
            }
            hasDropped = true;
        }
    }
    public override void BehaviorToPlayer()
    {
        DropItem();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasDropped)
        {
            Debug.Log("Player entered the trigger zone!");
            BehaviorToPlayer();
        }
    }
}
