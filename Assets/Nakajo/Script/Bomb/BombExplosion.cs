using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject Bomb;//このスクリプトをアタッチするオブジェクト
    private GameObject[] enemys;//爆風で破壊するオブジェクト名
    CircleCollider2D CircleCol2D;//enemysを破壊するためのコライダー
    private float ColSizeCount = 0; //コライダーのサイズをカウント
    private float DestroyCount = 0;//爆発後に消えるまでのカウント
    [Tooltip("爆風の最大範囲")][SerializeField]private float BomSize = 3.0f;
    [Tooltip("数値を大きくすると段階の回数を調整できる")][SerializeField]private float BomRadius = 1f;
    [Tooltip("拡大するタイミングの調整")][SerializeField]private float WaitTime = 0.1f;
    private bool isColliding = false;//OnTriggerEnter2Dが実行されたか確認

    void Start()
    {
        //エネミータグを取得
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //コライダーも判定を取得
        CircleCol2D = GetComponent<CircleCollider2D>();

        StartCoroutine(ExpandCollider());
    }

    void Update()
    {
        if (isColliding ==true)
        {
            //爆発後に自分を削除
            DestroyCount　+= Time.deltaTime;
            if (DestroyCount > 10f)
            {
                Destroy(this.gameObject);
            }
        }
        
    }

    //コライダーがだんだん大きくなる
    private IEnumerator ExpandCollider()
    {
        while (true)
        {
            if (ColSizeCount == 0)
            {

                BomRadius += Time.deltaTime + 0.6f;//爆風の広がる速度調整（＋１とかすればいい）
                CircleCol2D.radius = BomRadius;

                yield return new WaitForSeconds(WaitTime);//待機
            }
            if (BomSize < BomRadius)
            {
                ColSizeCount++;
            }

            yield return null;
        }
    }

    //触れたエネミーを削除
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("オブジェクトを破壊しました");
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2")
        {
            isColliding = true;
        }
    }


}
