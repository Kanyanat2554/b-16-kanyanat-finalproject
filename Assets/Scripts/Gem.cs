using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public string itemName; // ���ͧ͢ item (�ҡ��ͧ���)
    public int itemValue;   // ��Ңͧ item �ҡ��ͧ���������

    // �ѧ��ѹ������� item ��������� Player ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ǩ�ͺ��Ҽ���誹��� Player �������
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.CollectItem(this);  // ���¡�ѧ��ѹ� Player �������� item
            Destroy(gameObject);       // ����� object �����ѧ�ҡ��
        }
    }
}
