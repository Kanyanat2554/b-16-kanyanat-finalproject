using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainSpirit : Ally
{
    public override void Interact(Player player)
    {
        int earthGems = Random.Range(1, 4);
        int fireGems = Random.Range(1, 4);
        player.CollectGem("Earth", earthGems);
        player.CollectGem("Fire", fireGems);
        Debug.Log($"MountainSpirit dropped {earthGems} Earth gems and {fireGems} Fire gems");
    }
}
