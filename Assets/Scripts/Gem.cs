using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemValue = 1; // ��˹���Ңͧ Gem �������

    // �ѧ��ѹ������� Player �� Gem
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.CollectGem(this);  // ���¡�ѧ��ѹ� Player �������� Gem
            Destroy(gameObject);      // ����� Gem ��ѧ�ҡ��
        }
    }
}
