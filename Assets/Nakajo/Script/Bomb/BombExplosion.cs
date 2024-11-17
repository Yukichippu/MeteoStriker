using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject Bomb;//���̃X�N���v�g���A�^�b�`����I�u�W�F�N�g
    private GameObject[] enemys;//�����Ŕj�󂷂�I�u�W�F�N�g��
    CircleCollider2D CircleCol2D;//enemys��j�󂷂邽�߂̃R���C�_�[
    private float ColSizeCount = 0; //�R���C�_�[�̃T�C�Y���J�E���g
    private float DestroyCount = 0;//������ɏ�����܂ł̃J�E���g
    [Tooltip("�����̍ő�͈�")][SerializeField]private float BomSize = 3.0f;
    [Tooltip("���l��傫������ƒi�K�̉񐔂𒲐��ł���")][SerializeField]private float BomRadius = 1f;
    [Tooltip("�g�傷��^�C�~���O�̒���")][SerializeField]private float WaitTime = 0.1f;
    private bool isColliding = false;//OnTriggerEnter2D�����s���ꂽ���m�F

    void Start()
    {
        //�G�l�~�[�^�O���擾
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //�R���C�_�[��������擾
        CircleCol2D = GetComponent<CircleCollider2D>();

        StartCoroutine(ExpandCollider());
    }

    void Update()
    {
        if (isColliding ==true)
        {
            //������Ɏ������폜
            DestroyCount�@+= Time.deltaTime;
            if (DestroyCount > 10f)
            {
                Destroy(this.gameObject);
            }
        }
        
    }

    //�R���C�_�[�����񂾂�傫���Ȃ�
    private IEnumerator ExpandCollider()
    {
        while (true)
        {
            if (ColSizeCount == 0)
            {

                BomRadius += Time.deltaTime + 0.6f;//�����̍L���鑬�x�����i�{�P�Ƃ�����΂����j
                CircleCol2D.radius = BomRadius;

                yield return new WaitForSeconds(WaitTime);//�ҋ@
            }
            if (BomSize < BomRadius)
            {
                ColSizeCount++;
            }

            yield return null;
        }
    }

    //�G�ꂽ�G�l�~�[���폜
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("�I�u�W�F�N�g��j�󂵂܂���");
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2")
        {
            isColliding = true;
        }
    }


}
