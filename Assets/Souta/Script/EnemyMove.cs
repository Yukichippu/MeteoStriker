using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float Enemy_Shp = 1;//�G�l�~�[��HP
    [SerializeField] private float Enemy_Mhp = 2;//�G�l�~�[��HP
    [SerializeField] private float Enemy_Lhp = 3;//�G�l�~�[��HP
    [SerializeField] private float speed = 0;//�G�l�~�[�̊�b���x
    [SerializeField] private float acceleration = 0.1f;//�G�l�~�[�̗������x�����X�ɑ��������鐔�l
    private GameObject Enemy_S;
    private GameObject Enemy_M;
    private GameObject Enemy_L;

    private void Start()
    {
        Enemy_S = GameObject.Find("Enemy");
        Enemy_M = GameObject.Find("Enemy1");
        Enemy_L = GameObject.Find("Enemy2");
    }
    void Update()
    {
        Vector3 pos = transform.position;
        speed += acceleration * Time.deltaTime;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(this.gameObject);
        }//���e�ɂ��������Ƃ��ɏ����鏈��

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (this.gameObject == Enemy_S)
            {
                --Enemy_Shp;
                if (Enemy_Shp == 0)
                {
                    Destroy(this.gameObject);
                }
            }//�������G�̏��ŏ���
            else if (this.gameObject == Enemy_M)
            {
                --Enemy_Mhp;
                if (Enemy_Mhp == 0)
                {
                    Destroy(this.gameObject);
                }
            }//���̓G�̏��ŏ���
            else if (this.gameObject == Enemy_L)
            {
                --Enemy_Lhp;
                if (Enemy_Lhp == 0)
                {
                    Destroy(this.gameObject);
                }
            }//�傫���G�̏��ŏ���
            else
            { }
        }//�e�ɓ����������ɏ����鏈��

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }//�v���C���[�ɓ����������ɏ����鏈��
    }
}
