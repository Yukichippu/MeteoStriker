using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayer : MonoBehaviour
{
    [SerializeField]private float MoveSpeed = 0.4f;
    private float addSpeed = 0.035f;                //加速度
    Vector3 targetPosition = new Vector3(0, 14, 0); //Payerを退場させる座標
    Vector3 centerPosition = new Vector3(0, -4, 0); //Playerが真ん中に行くようにする座標

    private bool isCenter = false;                  //真ん中に到達したか判断

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
        if (MoveSpeed < 5)  //加速させる
        {
            MoveSpeed += addSpeed;
        }

        Transform objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector3.Lerp(objectTransform.position, centerPosition, MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(objectTransform.position, centerPosition) < 0.01f)
        {
            isCenter = true; // 中心に到達した
        }
    }

    void GoPlayer()
    {
        if (MoveSpeed < 5)  //加速させる
        {
            MoveSpeed += addSpeed;
        }

        Transform objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector3.Lerp(objectTransform.position, targetPosition, MoveSpeed * Time.deltaTime);

    }
}


