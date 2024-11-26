using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayer : MonoBehaviour
{
    [SerializeField]private float MoveSpeed = 0.4f;
    private float addSpeed = 0.035f;                //�����x
    Vector3 targetPosition = new Vector3(0, 14, 0); //Payer��ޏꂳ������W
    Vector3 centerPosition = new Vector3(0, -4, 0); //Player���^�񒆂ɍs���悤�ɂ�����W

    private bool isCenter = false;                  //�^�񒆂ɓ��B���������f

    void Update()
    {
        if (!isCenter)
        {
            CenterPlayer();
        }
        else
        {
            GoPlayer();
        }
    }
        void CenterPlayer()
    {
        if (MoveSpeed < 5)  //����������
        {
            MoveSpeed += addSpeed;
        }

        Transform objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector3.Lerp(objectTransform.position, centerPosition, MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(objectTransform.position, centerPosition) < 0.01f)
        {
            isCenter = true; // ���S�ɓ��B����
        }
    }

    void GoPlayer()
    {
        if (MoveSpeed < 5)  //����������
        {
            MoveSpeed += addSpeed;
        }

        Transform objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector3.Lerp(objectTransform.position, targetPosition, MoveSpeed * Time.deltaTime);

    }
}


