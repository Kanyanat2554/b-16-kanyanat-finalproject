using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamSpirit : Ally
{
    public override void Interact(Player player)
    {
        int windGems = Random.Range(1, 4);
        int waterGems = Random.Range(1, 4);
        player.CollectGem("Wind", windGems);
        player.CollectGem("Water", waterGems);
        Debug.Log($"StreamSpirit dropped {windGems} Wind gems and {waterGems} Water gems");
    }
}
