using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMystic : Ally
{
    private int healAmount;

    private void Start()
    {
        healAmount = Random.Range(10, 50);
    }

    public override void Interact(Player player)
    {
        player.TakeDamage(-healAmount); // ฮีลให้ Player
        healAmount = 0;  // ฮีลครั้งเดียว
    }
}
