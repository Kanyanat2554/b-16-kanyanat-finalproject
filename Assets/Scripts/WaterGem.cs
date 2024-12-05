using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGem : MonoBehaviour
{
    public int gemValue = 1; //Fix a value of water gem
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.CollectGem(this);
            Destroy(gameObject);

        }
    }
}
