using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosition : MonoBehaviour
{
    private GameObject[] enemys;//爆風で破壊するオブジェクト名
    CircleCollider2D CircleCol2D;//enemysを破壊するためのコライダー
    private float ColSizeCount = 0; //コライダーのサイズをカウント
    private float DestroyCount = 0;//爆発後に消えるまでのカウント
    [Tooltip("ミサイルの爆発範囲")][SerializeField] private float MissileSize = 1.0f;
    [Tooltip("数値を大きくすると段階の回数を調整できる")][SerializeField] private float ExpRadius = 0.5f;
    private bool isColliding = false;//OnTriggerEnter2Dが実行されたか確認

    void Start()
    {
        //エネミータグを取得
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //コライダーを取得
        CircleCol2D = GetComponent<CircleCollider2D>();
    }

    //コライダーをだんだん大きくする
    void FixedUpdate()
    {

        if (ColSizeCount == 0)
        {
            ExpRadius += Time.deltaTime;
            CircleCol2D.radius = ExpRadius;
        }
        if (MissileSize < ExpRadius)
        {
            ColSizeCount++;
        }
    }

    void Update()
    {
        if(isColliding == true)
        {
            //爆発後に自分を削除
            DestroyCount += Time.deltaTime;
            if (DestroyCount > 10f)
            {
                //Debug.Log("削除");
                Destroy(this.gameObject);
            }
        }
    }

    //エネミーとの接触を判断して削除
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2")
        {
            isColliding = true;
        }
    }
}
