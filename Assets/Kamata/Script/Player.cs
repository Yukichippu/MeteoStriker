using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f; // �v���C���[�̍��E�ւ̈ړ����x
    private void Update()
    {
        // �v���C���[�����݂̕����Ɉړ�
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ǂɏՓ˂����ꍇ
        if (collision.gameObject.CompareTag("Wall"))
        {
            ReverseDirection();
        }
    }

    private void ReverseDirection()
    {
        // �ړ����x�̕����𔽓]������i�ړ��������t�ɂ���j
        moveSpeed = -moveSpeed;
    }
}
