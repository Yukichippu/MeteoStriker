using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float[] hpList;
    [SerializeField] private float currentHP;
    [SerializeField] private float speed = 0;//エネミーの基礎速度
    [SerializeField] private float acceleration = 0.1f;//エネミーの落下速度を徐々に早くさせる数値
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(this.gameObject);
        }//爆弾にあたったときに消える処理

        if (collision.gameObject.CompareTag("Bullet"))
        {
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
            Destroy(this.gameObject);
        }//プレイヤーに当たった時に消える処理
    }
}
