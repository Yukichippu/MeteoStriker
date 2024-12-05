using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f; // プレイヤーの左右への移動速度
    [SerializeField] private float wideLength;
    bool isMoving = true;

    //Clear後のPlayerの変数
    private bool isCenter = false;                      //真ん中に移動したか確認
    private bool isGoal = false;
    [SerializeField] private float Cl_moveSpeed = 0.4f;
    private float Cl_addSpeed = 0.035f;                 //加速度
    Vector3 Cl_targetPosition = new Vector3(0, 14, 0);  //Payerを退場させる座標
    Vector3 Cl_centerPosition = new Vector3(0, -4, 0);  //Playerが真ん中に行くようにする座標

    private void Start()
    {
        GameObject obj = GameObject.Find("Player");
    }
    private void Update()
    {
        // プレイヤーを現在の方向に移動
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

        //クリア後の動作
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
        // 移動速度の符号を反転させる（移動方向を逆にする）
        wideLength = -wideLength;
        moveSpeed = -moveSpeed;
    }

    //プレイヤーが射撃とミサイルを打てなくする処理
    private void DestroyChild(Transform obj)
    {
        foreach(Transform child in obj)
        {
            Destroy(child.gameObject);
        }
    }

    //プレイヤーのゴール時の処理
    public void GoalPlayer()
    {
        isGoal = true;          //ゴールした
        DestroyChild(transform);//射撃を止めた
    }

    //プレイヤーがゴール時真ん中に来るようにする処理
    void CenterPlayer()
    {
        if (isGoal)
        {
            Transform objectTransform = gameObject.GetComponent<Transform>();
            objectTransform.position = Vector3.Lerp(objectTransform.position, Cl_centerPosition, Cl_moveSpeed * Time.deltaTime);

            if (Vector3.Distance(objectTransform.position, Cl_centerPosition) < 0.01f)
            {
                isCenter = true; // 中心に到達した
                isMoving = false;//動きを停止
            }
        }
    }

    //プレイヤーがゴール時画面外に退場する処理
    void GoPlayer()
    {
        if (Cl_moveSpeed < 5)  //加速させる
        {
            Cl_moveSpeed += Cl_addSpeed;
        }

        Transform objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector3.Lerp(objectTransform.position, Cl_targetPosition, Cl_moveSpeed * Time.deltaTime);

    }
}
