using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f; // �v���C���[�̍��E�ւ̈ړ����x
    [SerializeField] private float wideLength;
    bool isMoving = true;

    //Clear���Player�̕ϐ�
    private bool isCenter = false;                      //�^�񒆂Ɉړ��������m�F
    private bool isGoal = false;
    [SerializeField] private float Cl_moveSpeed = 0.4f;
    private float Cl_addSpeed = 0.035f;                 //�����x
    Vector3 Cl_targetPosition = new Vector3(0, 14, 0);  //Payer��ޏꂳ������W
    Vector3 Cl_centerPosition = new Vector3(0, -4, 0);  //Player���^�񒆂ɍs���悤�ɂ�����W

    private void Start()
    {
        GameObject obj = GameObject.Find("Player");
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

        //�N���A��̓���
        if (!isCenter)
        {
            CenterPlayer();
        }
        else
        {
            GoPlayer();
        }

    }

    private void ReverseDirection()
    {
        // �ړ����x�̕����𔽓]������i�ړ��������t�ɂ���j
        wideLength = -wideLength;
        moveSpeed = -moveSpeed;
    }

    //�v���C���[���ˌ��ƃ~�T�C����łĂȂ����鏈��
    private void DestroyChild(Transform obj)
    {
        foreach(Transform child in obj)
        {
            Destroy(child.gameObject);
        }
    }

    //�v���C���[�̃S�[�����̏���
    public void GoalPlayer()
    {
        isGoal = true;          //�S�[������
        DestroyChild(transform);//�ˌ����~�߂�
    }

    //�v���C���[���S�[�����^�񒆂ɗ���悤�ɂ��鏈��
    void CenterPlayer()
    {
        if (isGoal)
        {
            Transform objectTransform = gameObject.GetComponent<Transform>();
            objectTransform.position = Vector3.Lerp(objectTransform.position, Cl_centerPosition, Cl_moveSpeed * Time.deltaTime);

            if (Vector3.Distance(objectTransform.position, Cl_centerPosition) < 0.01f)
            {
                isCenter = true; // ���S�ɓ��B����
                isMoving = false;//�������~
            }
        }
    }

    //�v���C���[���S�[������ʊO�ɑޏꂷ�鏈��
    void GoPlayer()
    {
        if (Cl_moveSpeed < 5)  //����������
        {
            Cl_moveSpeed += Cl_addSpeed;
        }

        Transform objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector3.Lerp(objectTransform.position, Cl_targetPosition, Cl_moveSpeed * Time.deltaTime);

    }
}
