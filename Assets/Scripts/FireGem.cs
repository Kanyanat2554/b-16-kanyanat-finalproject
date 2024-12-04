using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGem : MonoBehaviour
{
    public int gemValue = 2;
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
