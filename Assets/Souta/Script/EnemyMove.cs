using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float[] hpList;
    [SerializeField] private float currentHP;
    [SerializeField] private float speed;//�G�l�~�[�̊�b���x
    [SerializeField] private float acceleration = 0.1f;//�G�l�~�[�̗������x�����X�ɑ��������鐔�l
    [SerializeField] private float DeadPos = -6f;
    [SerializeField] private GameObject PlayerEXP;
    private enum EnemyType
    {
        S,
        M,
        L,
        EX,
    }
    [SerializeField] EnemyType enemyType = EnemyType.S;

    private void Start()
    {
        currentHP = hpList[(int)enemyType];
    }
    void Update()
    {
        Vector3 pos = transform.position;
        speed += acceleration * Time.deltaTime;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;

        if(transform.position.y < DeadPos)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(this.gameObject);
        }//���e�ɂ��������Ƃ��ɏ����鏈��

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (gameObject.CompareTag("Enemy1") || gameObject.CompareTag("Enemy2"))
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
                Invoke("HitBack", 0.2f);
            }//�傫���G�ƒ����炢�̓G�̓����������ɐF���ς��(0.2�b��Ɍ��ɖ߂�)
            if (enemyType == EnemyType.EX)
            {
                return;
            }
                currentHP--;
            if(currentHP == 0)
            {

                Destroy(this.gameObject);
            }
           
        }//�e�ɓ����������ɏ����鏈��

        if(this.gameObject.CompareTag("Bomb"))
        {
            if (enemyType == EnemyType.EX)
             {
                currentHP--;
                if (currentHP == 0)
                {
                    Destroy(this.gameObject);
                }
             }//���e�ł����|���Ȃ��G�̏��ŏ���
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 ExpPos = transform.position;
            Instantiate(PlayerEXP, ExpPos, Quaternion.identity);
            //�G�������ʒu�ɃG�t�F�N�g�𐶐�

            Destroy(this.gameObject);
        }//�v���C���[�ɓ����������ɏ����鏈��
    }

    void HitBack()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
    }//�F�����ɖ߂�����
}
