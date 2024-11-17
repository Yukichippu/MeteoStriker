using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float[] hpList;
    [SerializeField] private float currentHP;
    [SerializeField] private float speed;//エネミーの基礎速度
    [SerializeField] private float acceleration = 0.1f;//エネミーの落下速度を徐々に早くさせる数値
    [SerializeField] private float DeadPos = -6f;
    [SerializeField] private GameObject PlayerEXP;
    private enum EnemyType
    {
        S,
        M,
        L,
        EX,
    }
    [SerializeField] EnemyType enemyType = EnemyType.S;

    private void Start()
    {
        currentHP = hpList[(int)enemyType];
    }
    void Update()
    {
        Vector3 pos = transform.position;
        speed += acceleration * Time.deltaTime;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;

        if(transform.position.y < DeadPos)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(this.gameObject);
        }//爆弾にあたったときに消える処理

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (gameObject.CompareTag("Enemy1") || gameObject.CompareTag("Enemy2"))
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
                Invoke("HitBack", 0.2f);
            }//大きい敵と中くらいの敵の当たった時に色が変わる(0.2秒後に元に戻る)
            if (enemyType == EnemyType.EX)
            {
                return;
            }
                currentHP--;
            if(currentHP == 0)
            {

                Destroy(this.gameObject);
            }
           
        }//弾に当たった時に消える処理

        if(this.gameObject.CompareTag("Bomb"))
        {
            if (enemyType == EnemyType.EX)
             {
                currentHP--;
                if (currentHP == 0)
                {
                    Destroy(this.gameObject);
                }
             }//爆弾でしか倒せない敵の消滅処理
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 ExpPos = transform.position;
            Instantiate(PlayerEXP, ExpPos, Quaternion.identity);
            //敵がいた位置にエフェクトを生成

            Destroy(this.gameObject);
        }//プレイヤーに当たった時に消える処理
    }

    void HitBack()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
    }//色を元に戻す処理
}
