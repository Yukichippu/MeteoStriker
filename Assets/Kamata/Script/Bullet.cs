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

        // Y座標がminYPositionより下であれば制限する
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
        ball.AddComponent<BallMovement>().SetDirectionAndSpeed(direction, BulletSpeed, maxDistance, transform.position);
    }
}

// 弾が指定された方向に進むクラス
public class BallMovement : MonoBehaviour
{
    private Vector3 moveDirection; // 弾が進む方向
    private float speed; // 弾の速度
    private float maxDistance; // 弾が消える最大距離
    private Vector3 spawnPosition; // 弾の発射位置

    public void SetDirectionAndSpeed(Vector3 direction, float speed, float maxDistance, Vector3 spawnPosition)
    {
        this.moveDirection = direction;
        this.speed = speed; // 初期速度をそのまま使用
        this.maxDistance = maxDistance;
        this.spawnPosition = spawnPosition;
    }

    void Update()
    {
        // 弾を方向に沿って移動
        transform.position += moveDirection * speed * Time.deltaTime;

        // 現在の位置と発射位置の距離を計算
        float distanceFromSpawn = Vector3.Distance(transform.position, spawnPosition);

        // 一定距離を超えたら弾を消す
        if (distanceFromSpawn > maxDistance)
        {
            Destroy(gameObject); // 弾を削除
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Wall"タグのついたオブジェクトに衝突したら弾を削除
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // 衝突した弾を削除
        }
        // "Bullet"タグのついたオブジェクトに衝突したら弾を削除
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // 衝突した弾を削除
        }
    }
}