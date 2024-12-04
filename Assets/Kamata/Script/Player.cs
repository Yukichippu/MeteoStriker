using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f; // �v���C���[�̍��E�ւ̈ړ����x
    [SerializeField] private float wideLength;
    bool isMoving = true;

    private void Start()
    {
       
    }
    private void Update()
    {
        // �v���C���[�����݂̕����Ɉړ�
        if(isMoving)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (Mathf.Abs(transform.position.x) > Mathf.Abs(wideLength))
            {
                var pos = transform.position;
                pos.x = wideLength;
                transform.position = pos;
                ReverseDirection();
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ǂɏՓ˂����ꍇ
        if (collision.gameObject.CompareTag("Wall"))
        {
            //ReverseDirection();
        }
    }

    private void ReverseDirection()
    {
        // �ړ����x�̕����𔽓]������i�ړ��������t�ɂ���j
        wideLength = -wideLength;
        moveSpeed = -moveSpeed;
    }

    public void GoalPlayer()
    {
        isMoving = false;
    }
}
