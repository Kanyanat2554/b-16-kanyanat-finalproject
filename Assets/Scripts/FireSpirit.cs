using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieSpirit : Ally, IGemDroppable
{
    public void DropGems(Player player)
    {
        int gemCount = Random.Range(1, 4);
        for (int i = 0; i < gemCount; i++)
        {
            player.CollectGem("Fire");
        }
        Debug.Log($"Dropped {gemCount} Fire gems");
    }
}
