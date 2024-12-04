using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpirit : Ally, IDroppable
{
    public GameObject[] waterPotionToDrop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasDropped)
        {
            Debug.Log("Player entered the trigger zone!");
            BehaviorToPlayer();
        }
    }

    public override void BehaviorToPlayer()
    {
        DropItem();
    }
    public void DropItem()
    {
        if (waterPotionToDrop.Length > 0)
        {
            int numberOfItemsToDrop = Random.Range(1, 7);

            for (int i = 0; i < numberOfItemsToDrop; i++)
            {
                int randomIndex = Random.Range(0, waterPotionToDrop.Length);
                GameObject itemToDrop = waterPotionToDrop[randomIndex];

                Debug.Log("Dropping item at position: " + dropPoint.position);

                Instantiate(itemToDrop, dropPoint.position, Quaternion.identity);
                Debug.Log("Item Dropped!");
            }
            hasDropped = true;
        }
    }
}
