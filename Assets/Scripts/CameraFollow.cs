using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference ��ѧ Player �����ͧ�еԴ���
    public Vector3 offset;    // ������ҧ�����ҧ���ͧ��� Player
    public float smoothSpeed = 0.125f;  // �����������㹡������͹���ͧ���ͧ

    private void LateUpdate()
    {
        if (player != null)
        {
            // ��˹����˹�����ͧ���ͧ������˹觢ͧ Player ���������ҧ offset
            Vector3 desiredPosition = player.position + offset;

            // �� Lerp ���ͷ����������͹���ͧ���ͧ�������
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    //Reference Tutorial: https://www.youtube.com/watch?v=MFQhpwc6cKE
}
