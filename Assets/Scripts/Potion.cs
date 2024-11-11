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
            int randomHp = Random.Range(minHp, maxHp + 1); // ���� HP Ẻ��������� 30 �֧ 50
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.AddHealth(randomHp); // ���� HP ���Ѻ Player
            }

            Destroy(gameObject); // �����������͡�ҡ Scene
        }
    }
}
