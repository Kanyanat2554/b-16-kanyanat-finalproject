using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference ไปยัง Player ที่กล้องจะติดตาม
    public Vector3 offset;    // ระยะห่างระหว่างกล้องและ Player
    public float smoothSpeed = 0.125f;  // ความนุ่มนวลในการเคลื่อนที่ของกล้อง

    private void LateUpdate()
    {
        if (player != null)
        {
            // กำหนดตำแหน่งใหม่ของกล้องตามตำแหน่งของ Player และระยะห่าง offset
            Vector3 desiredPosition = player.position + offset;

            // ใช้ Lerp เพื่อทำให้การเคลื่อนที่ของกล้องนุ่มนวล
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
