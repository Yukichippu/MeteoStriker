using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public GameObject bombPrefab; // 爆弾のPrefab
    [SerializeField] public float bombSpeed = 10f; // 爆弾の速度
    [SerializeField] public float shootCooldown = 0.5f; //爆弾の発射間隔
    [SerializeField] public float maxDistance = 15f; // 爆弾が消える最大距離
    [SerializeField] private float YPosition = 200f; // マウスのY座標の下限値


    void Update()
    {
        //// クールタイム中は爆弾を発射しない
        //if (Time.time > nextShootTime)
        //{
        //    // 左クリックで爆弾を発射
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        ShootBomb();
        //        nextShootTime = Time.time + shootCooldown; // 次の発射時間を更新
        //    }
        //}
    }

    public void ShootBomb()
    {
        // マウスのスクリーン座標を取得
        Vector3 mousePosition = Input.mousePosition;

        // マウスのY座標がYPositionより下であれば制限する
        if (mousePosition.y < YPosition)
        {
            mousePosition.y = YPosition;
        }

        // マウスのスクリーン座標をワールド座標に変換 (Z軸をカメラからの一定距離に設定)
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z * -1f));

        // 爆弾の発射位置（このオブジェクトの位置）
        Vector3 shootPosition = transform.position;

        // マウスまでの方向を計算
        Vector3 shootDirection = (worldMousePosition - shootPosition).normalized; // 方向を正規化して、常に長さ1のベクトルにする

        // **爆弾が下に向かわないように調整**
        if (shootDirection.y < 0)
        {
            shootDirection.y = 0; // Y軸方向の成分が負（下方向）の場合は0にする
        }

        // 爆弾を生成
        GameObject bomb = Instantiate(bombPrefab, shootPosition, Quaternion.identity);

        // 爆弾に力を加えてマウスの方向に発射
        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();

        // 重力の影響を無効にして、落下しないようにする
        rb.gravityScale = 0;

        // 一定の速度でマウスの方向に発射
        rb.velocity = shootDirection * bombSpeed;

        // BombMovement スクリプトを追加して、距離や壁に当たった場合の削除処理を行う
        bomb.AddComponent<BombMovement>().Initialize(shootPosition, maxDistance);
    }
}

// 爆弾の動きと削除処理を管理するクラス
public class BombMovement : MonoBehaviour
{
    private Vector3 spawnPosition; // 爆弾が発射された位置
    private float maxDistance; // 爆弾が消える最大距離
    [SerializeField] private float angle;

    public void Initialize(Vector3 spawnPosition, float maxDistance)
    {
        this.spawnPosition = spawnPosition;
        this.maxDistance = maxDistance;
        angle = Mathf.Atan2(spawnPosition.y, spawnPosition.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle * Mathf.Rad2Deg -90f));
    }

    void Update()
    {
        // 現在の位置と発射位置の距離を計算
        float distanceFromSpawn = Vector3.Distance(transform.position, spawnPosition);

        // 一定距離を超えたら爆弾を削除
        if (distanceFromSpawn > maxDistance)
        {
            Destroy(gameObject); // 爆弾を削除
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Wall"タグのついたオブジェクトに衝突したら爆弾を削除
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // 壁に当たった爆弾を削除
        }
    }
}