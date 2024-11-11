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
            int randomHp = Random.Range(minHp, maxHp + 1); // ���� HP Ẻ��������� 30 �֧ 50
            Player playerHealth = other.GetComponent<Player>();

            if (playerHealth != null)
            {
                playerHealth.AddHealth(randomHp); // ���� HP ���Ѻ Player
            }

            Destroy(gameObject); // �����������͡�ҡ Scene
        }
    }
}
