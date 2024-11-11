using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMystic : Ally
{
    public GameObject itemsToDrop; // �������� NPC �д�ͻ
    public float dropRadius = 3f; // ���з�� Player ��ͧ������֧�д�ͻ�����
    private bool hasDropped = false;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // �� Player �ҡ Tag
    }

    private void Update()
    {
        if (!hasDropped && Vector3.Distance(transform.position, player.position) <= dropRadius)
        {
            DropItem(); // ��ͻ���������� Player ����������
        }
    }

    private void DropItem()
    {
        Instantiate(itemsToDrop, transform.position, Quaternion.identity); // ���ҧ����������˹觢ͧ NPC
        hasDropped = true;
    }
}
