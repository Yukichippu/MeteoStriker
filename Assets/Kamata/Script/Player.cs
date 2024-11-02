using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f; // プレイヤーの左右への移動速度
    private void Update()
    {
        // プレイヤーを現在の方向に移動
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 壁に衝突した場合
        if (collision.gameObject.CompareTag("Wall"))
        {
            ReverseDirection();
        }
    }

    private void ReverseDirection()
    {
        // 移動速度の符号を反転させる（移動方向を逆にする）
        moveSpeed = -moveSpeed;
    }
}
