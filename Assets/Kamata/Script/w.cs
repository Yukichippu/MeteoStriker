using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w : MonoBehaviour
{
    public float CameraSpeed = 5f; // �ړ����x

    void Update()
    {
        // Y���̃v���X�����Ɉړ�
        Vector3 movement = new Vector3(0, CameraSpeed * Time.deltaTime, 0);
        transform.position += movement;
    }
}
