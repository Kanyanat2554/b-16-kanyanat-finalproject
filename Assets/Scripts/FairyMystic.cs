using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMystic : Ally
{
    public void Heal(Player player)
    {
        int healAmount = Random.Range(30, 51);
        player.TakeDamage(-healAmount); // Negative damage to heal
        Debug.Log($"Player healed for {healAmount} HP");
    }
}
