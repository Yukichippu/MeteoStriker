using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

// �e���w�肳�ꂽ�����ɐi�ރN���X
public class BallMovement : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection; // �e���i�ޕ���
    [SerializeField] private float angle;
    private float speed; // �e�̑��x
    private float maxDistance; // �e��������ő勗��
    private Vector3 spawnPosition; // �e�̔��ˈʒu

    public void SetDirectionAndSpeed(Vector3 direction, float speed, float maxDistance, Vector3 spawnPosition)
    {
        this.moveDirection = direction;
        this.speed = speed; // �������x�����̂܂܎g�p
        this.maxDistance = maxDistance;
        this.spawnPosition = spawnPosition;
        angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f,0f, angle * Mathf.Rad2Deg - 90f));
    }

    void Update()
    {
        // �e������ɉ����Ĉړ�
        transform.position += moveDirection * speed * Time.deltaTime;

        // ���݂̈ʒu�Ɣ��ˈʒu�̋������v�Z
        float distanceFromSpawn = Vector3.Distance(transform.position, spawnPosition);

        // ��苗���𒴂�����e������
        if (distanceFromSpawn > maxDistance)
        {
            Destroy(gameObject); // �e���폜
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit: " + collision.gameObject.tag);
        // "Wall"�^�O�̂����I�u�W�F�N�g�ɏՓ˂�����e���폜
        if (collision.gameObject.CompareTag("Wall"))
        {

            Destroy(gameObject); // �Փ˂����e���폜
        }
        // "Enemy"�^�O�̂����I�u�W�F�N�g�ɏՓ˂�����e���폜
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            //Destroy(gameObject); // �Փ˂����e���폜
        }
    }
}