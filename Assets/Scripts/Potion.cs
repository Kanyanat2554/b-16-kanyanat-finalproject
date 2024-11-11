using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private int minHp = 30;
    private int maxHp = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int randomHp = Random.Range(minHp, maxHp + 1); // เพิ่ม HP แบบสุ่มตั้งแต่ 30 ถึง 50
            Player playerHealth = other.GetComponent<Player>();

            if (playerHealth != null)
            {
                playerHealth.AddHealth(randomHp); // เพิ่ม HP ให้กับ Player
            }

            Destroy(gameObject); // ทำลายไอเท็มออกจาก Scene
        }
    }
}
