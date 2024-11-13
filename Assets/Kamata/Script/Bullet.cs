using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab; //弾のPrefab
    [SerializeField] private float BulletSpeed = 5f; // 弾の速度
    [SerializeField] private float spawnRate = 0.5f; // 弾の発射間隔
    [SerializeField] private float maxDistance = 10f; // 弾が消える最大距離
    [SerializeField] private float nextSpawnTime = 0f; // 次に弾を生成する時間
    [SerializeField] private float YPosition = 200f; // マウスのY座標の下限値

    void Update()
    {
        // 時間が経過したら弾を生成
        if (Time.time > nextSpawnTime)
        {
            SpawnBallTowardsMouse();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnBallTowardsMouse()
    {
        // マウスのスクリーン座標を取得
        Vector3 mousePosition = Input.mousePosition;

        // Y座標がYPositionより下であれば制限する
        if (mousePosition.y < YPosition)
        {
            mousePosition.y = YPosition;
        }

        // マウスのスクリーン座標をワールド座標に変換
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // アタッチしたオブジェクトの位置を基準にマウスまでの方向を計算
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Y成分を0に設定して、弾が下に行かないようにする
        direction.y = Mathf.Max(direction.y, 0); // Y成分が負にならないように制限

        // 弾を発射（アタッチされたオブジェクトの位置）で生成
        GameObject ball = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

        // 弾に向かう方向と速度、消える最大距離を設定
        ball.GetComponent<BallMovement>().SetDirectionAndSpeed(direction, BulletSpeed, maxDistance, transform.position);
    }
}

