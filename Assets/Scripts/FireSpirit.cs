using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpirit : Ally
{
    public GameObject[] itemsToDrop;
    public Transform dropPoint;// ��¡�� Prefab �ͧ������� NPC ����ö��ͻ��
    public float dropRadius = 3f;     // ���з�� Player ��ͧ�Թ��ҹ
    private bool hasDropped = false;  // ����� NPC ��ͻ�������������ѧ

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ǩ�ͺ��� object ��誹��� Player ����ѧ����ͻ����
        if (other.CompareTag("Player") && !hasDropped)
        {
            Debug.Log("Player entered the trigger zone!");
            DropItem();
        }
    }

    void DropItem()
    {
        if (itemsToDrop.Length > 0)
        {
            // �����ӹǹ�������д�ͻ (�����ҧ 1 �֧ 9 ���)
            int numberOfItemsToDrop = Random.Range(1, 10);  // �ӹǹ����ͻ�����������ҧ 1-9

            // ��ͻ��������ӹǹ���������
            for (int i = 0; i < numberOfItemsToDrop; i++)
            {
                // �������͡�����ҡ��¡��
                int randomIndex = Random.Range(0, itemsToDrop.Length);
                GameObject itemToDrop = itemsToDrop[randomIndex];

                // ��Ǩ�ͺ���˹觷�������д�ͻ
                Debug.Log("Dropping item at position: " + dropPoint.position);

                // ���ҧ�������١��ͻ㹵��˹觷���˹�
                Instantiate(itemToDrop, dropPoint.position, Quaternion.identity);
                Debug.Log("Item Dropped!");
            }

            // ��˹���� NPC ��ͻ��������
            hasDropped = true;
        }
    }


}
