using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public GameObject bombPrefab; // ���e��Prefab
    [SerializeField] public float bombSpeed = 10f; // ���e�̑��x
    [SerializeField] public float shootCooldown = 0.5f; //���e�̔��ˊԊu
    [SerializeField] public float maxDistance = 15f; // ���e��������ő勗��
    [SerializeField] private float YPosition = 200f; // �}�E�X��Y���W�̉����l


    void Update()
    {
        //// �N�[���^�C�����͔��e�𔭎˂��Ȃ�
        //if (Time.time > nextShootTime)
        //{
        //    // ���N���b�N�Ŕ��e�𔭎�
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        ShootBomb();
        //        nextShootTime = Time.time + shootCooldown; // ���̔��ˎ��Ԃ��X�V
        //    }
        //}
    }

    public void ShootBomb()
    {
        // �}�E�X�̃X�N���[�����W���擾
        Vector3 mousePosition = Input.mousePosition;

        // �}�E�X��Y���W��YPosition��艺�ł���ΐ�������
        if (mousePosition.y < YPosition)
        {
            mousePosition.y = YPosition;
        }

        // �}�E�X�̃X�N���[�����W�����[���h���W�ɕϊ� (Z�����J��������̈�苗���ɐݒ�)
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z * -1f));

        // ���e�̔��ˈʒu�i���̃I�u�W�F�N�g�̈ʒu�j
        Vector3 shootPosition = transform.position;

        // �}�E�X�܂ł̕������v�Z
        Vector3 shootDirection = (worldMousePosition - shootPosition).normalized; // �����𐳋K�����āA��ɒ���1�̃x�N�g���ɂ���

        // **���e�����Ɍ�����Ȃ��悤�ɒ���**
        if (shootDirection.y < 0)
        {
            shootDirection.y = 0; // Y�������̐��������i�������j�̏ꍇ��0�ɂ���
        }

        // ���e�𐶐�
        GameObject bomb = Instantiate(bombPrefab, shootPosition, Quaternion.identity);

        // ���e�ɗ͂������ă}�E�X�̕����ɔ���
        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();

        // �d�͂̉e���𖳌��ɂ��āA�������Ȃ��悤�ɂ���
        rb.gravityScale = 0;

        // ���̑��x�Ń}�E�X�̕����ɔ���
        rb.velocity = shootDirection * bombSpeed;

        // BombMovement �X�N���v�g��ǉ����āA������ǂɓ��������ꍇ�̍폜�������s��
        bomb.AddComponent<BombMovement>().Initialize(shootPosition, maxDistance);
    }
}

// ���e�̓����ƍ폜�������Ǘ�����N���X
public class BombMovement : MonoBehaviour
{
    private Vector3 spawnPosition; // ���e�����˂��ꂽ�ʒu
    private float maxDistance; // ���e��������ő勗��
    [SerializeField] private float angle;

    public void Initialize(Vector3 spawnPosition, float maxDistance)
    {
        this.spawnPosition = spawnPosition;
        this.maxDistance = maxDistance;
        angle = Mathf.Atan2(spawnPosition.y, spawnPosition.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle * Mathf.Rad2Deg -90f));
    }

    void Update()
    {
        // ���݂̈ʒu�Ɣ��ˈʒu�̋������v�Z
        float distanceFromSpawn = Vector3.Distance(transform.position, spawnPosition);

        // ��苗���𒴂����甚�e���폜
        if (distanceFromSpawn > maxDistance)
        {
            Destroy(gameObject); // ���e���폜
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Wall"�^�O�̂����I�u�W�F�N�g�ɏՓ˂����甚�e���폜
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // �ǂɓ����������e���폜
        }
    }
}