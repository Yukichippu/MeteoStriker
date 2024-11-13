using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab; //�e��Prefab
    [SerializeField] private float BulletSpeed = 5f; // �e�̑��x
    [SerializeField] private float spawnRate = 0.5f; // �e�̔��ˊԊu
    [SerializeField] private float maxDistance = 10f; // �e��������ő勗��
    [SerializeField] private float nextSpawnTime = 0f; // ���ɒe�𐶐����鎞��
    [SerializeField] private float YPosition = 200f; // �}�E�X��Y���W�̉����l

    void Update()
    {
        // ���Ԃ��o�߂�����e�𐶐�
        if (Time.time > nextSpawnTime)
        {
            SpawnBallTowardsMouse();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnBallTowardsMouse()
    {
        // �}�E�X�̃X�N���[�����W���擾
        Vector3 mousePosition = Input.mousePosition;

        // Y���W��YPosition��艺�ł���ΐ�������
        if (mousePosition.y < YPosition)
        {
            mousePosition.y = YPosition;
        }

        // �}�E�X�̃X�N���[�����W�����[���h���W�ɕϊ�
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // �A�^�b�`�����I�u�W�F�N�g�̈ʒu����Ƀ}�E�X�܂ł̕������v�Z
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Y������0�ɐݒ肵�āA�e�����ɍs���Ȃ��悤�ɂ���
        direction.y = Mathf.Max(direction.y, 0); // Y���������ɂȂ�Ȃ��悤�ɐ���

        // �e�𔭎ˁi�A�^�b�`���ꂽ�I�u�W�F�N�g�̈ʒu�j�Ő���
        GameObject ball = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

        // �e�Ɍ����������Ƒ��x�A������ő勗����ݒ�
        ball.GetComponent<BallMovement>().SetDirectionAndSpeed(direction, BulletSpeed, maxDistance, transform.position);
    }
}

