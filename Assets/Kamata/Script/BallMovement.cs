using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

// 弾が指定された方向に進むクラス
public class BallMovement : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection; // 弾が進む方向
    [SerializeField] private float angle;
    private float speed; // 弾の速度
    private float maxDistance; // 弾が消える最大距離
    private Vector3 spawnPosition; // 弾の発射位置

    public void SetDirectionAndSpeed(Vector3 direction, float speed, float maxDistance, Vector3 spawnPosition)
    {
        this.moveDirection = direction;
        this.speed = speed; // 初期速度をそのまま使用
        this.maxDistance = maxDistance;
        this.spawnPosition = spawnPosition;
        angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f,0f, angle * Mathf.Rad2Deg - 90f));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit: " + collision.gameObject.tag);
        // "Wall"タグのついたオブジェクトに衝突したら弾を削除
        if (collision.gameObject.CompareTag("Wall"))
        {

            Destroy(gameObject); // 衝突した弾を削除
        }
        // "Enemy"タグのついたオブジェクトに衝突したら弾を削除
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            //Destroy(gameObject); // 衝突した弾を削除
        }
    }
}