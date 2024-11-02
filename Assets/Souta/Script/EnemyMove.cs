using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float Enemy_Shp = 1;//エネミーのHP
    [SerializeField] private float Enemy_Mhp = 2;//エネミーのHP
    [SerializeField] private float Enemy_Lhp = 3;//エネミーのHP
    [SerializeField] private float speed = 0;//エネミーの基礎速度
    [SerializeField] private float acceleration = 0.1f;//エネミーの落下速度を徐々に早くさせる数値
    private GameObject Enemy_S;
    private GameObject Enemy_M;
    private GameObject Enemy_L;

    private void Start()
    {
        Enemy_S = GameObject.Find("Enemy");
        Enemy_M = GameObject.Find("Enemy1");
        Enemy_L = GameObject.Find("Enemy2");
    }
    void Update()
    {
        Vector3 pos = transform.position;
        speed += acceleration * Time.deltaTime;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(this.gameObject);
        }//爆弾にあたったときに消える処理

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (this.gameObject == Enemy_S)
            {
                --Enemy_Shp;
                if (Enemy_Shp == 0)
                {
                    Destroy(this.gameObject);
                }
            }//小さい敵の消滅処理
            else if (this.gameObject == Enemy_M)
            {
                --Enemy_Mhp;
                if (Enemy_Mhp == 0)
                {
                    Destroy(this.gameObject);
                }
            }//中の敵の消滅処理
            else if (this.gameObject == Enemy_L)
            {
                --Enemy_Lhp;
                if (Enemy_Lhp == 0)
                {
                    Destroy(this.gameObject);
                }
            }//大きい敵の消滅処理
            else
            { }
        }//弾に当たった時に消える処理

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }//プレイヤーに当たった時に消える処理
    }
}
