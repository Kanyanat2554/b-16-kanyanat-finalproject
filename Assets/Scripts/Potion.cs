using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private int minHp = 30;
    private int maxHp = 50;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            Debug.Log(other);
            int randomHp = Random.Range(minHp, maxHp + 1); // เพิ่ม HP แบบสุ่มตั้งแต่ 30 ถึง 50
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.AddHealth(randomHp); // เพิ่ม HP ให้กับ Player
            }

            Destroy(gameObject); // ทำลายไอเท็มออกจาก Scene
        }
    }
}
