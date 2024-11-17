using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosition : MonoBehaviour
{
    private GameObject[] enemys;//�����Ŕj�󂷂�I�u�W�F�N�g��
    CircleCollider2D CircleCol2D;//enemys��j�󂷂邽�߂̃R���C�_�[
    private float ColSizeCount = 0; //�R���C�_�[�̃T�C�Y���J�E���g
    private float DestroyCount = 0;//������ɏ�����܂ł̃J�E���g
    [Tooltip("�~�T�C���̔����͈�")][SerializeField] private float MissileSize = 1.0f;
    [Tooltip("���l��傫������ƒi�K�̉񐔂𒲐��ł���")][SerializeField] private float ExpRadius = 0.5f;
    private bool isColliding = false;//OnTriggerEnter2D�����s���ꂽ���m�F

    void Start()
    {
        //�G�l�~�[�^�O���擾
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //�R���C�_�[���擾
        CircleCol2D = GetComponent<CircleCollider2D>();
    }

    //�R���C�_�[�����񂾂�傫������
    void FixedUpdate()
    {

        if (ColSizeCount == 0)
        {
            ExpRadius += Time.deltaTime;
            CircleCol2D.radius = ExpRadius;
        }
        if (MissileSize < ExpRadius)
        {
            ColSizeCount++;
        }
    }

    void Update()
    {
        if(isColliding == true)
        {
            //������Ɏ������폜
            DestroyCount += Time.deltaTime;
            if (DestroyCount > 10f)
            {
                //Debug.Log("�폜");
                Destroy(this.gameObject);
            }
        }
    }

    //�G�l�~�[�Ƃ̐ڐG�𔻒f���č폜
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2")
        {
            isColliding = true;
        }
    }
}
