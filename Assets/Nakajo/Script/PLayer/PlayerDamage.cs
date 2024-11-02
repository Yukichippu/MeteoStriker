using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private float LifeCount = 3;//残機
    private bool Invincible = false;//無敵かどうか
    private float InvincibleTime = 0;//無敵時間のカウント
    private Collider2D Col;
    [Tooltip("無敵の時間")][SerializeField]private float InvincibleEnd = 1;

    [SerializeField] GameObject Hearts1;//1つ目のハート
    [SerializeField] GameObject Hearts2;//２つ目のハート
    [SerializeField] GameObject Hearts3;//３つ目のハート


    void Start()
    {
        Col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Invincible == true)
        {
            Debug.Log("カウント開始");
            //無敵時間カウント開始
            InvincibleTime += Time.deltaTime;
        }
        EndInvincible();
    }

    //エネミーに当たったら
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("残機ー１");
            //残機-1
            LifeCount -= 1;
            PlayerLifeUI();
            //無敵関数呼び出し
            StartInvincible();
            DeadPlayer();
        }
    }

    //無敵開始の関数
    private void StartInvincible()
    {
        Debug.Log("無敵開始");
        //無敵をON
        Invincible = true;
        //コライダーをOFF
        if(Invincible == true)
        {
            Col.enabled = false;
        }
    }

    //無敵終了の関数
    private void EndInvincible()
    {
            if (InvincibleTime > InvincibleEnd)
            {
                Debug.Log("無敵終了");
                //無敵をOFF
                Invincible = false;
                //コライダーをON
                Col.enabled = true;
                InvincibleTime = 0;
            }
    }

    //プレイヤーの死亡を判断する関数
    private void DeadPlayer()
    {
        if (LifeCount == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void PlayerLifeUI()
    {
       
        if(Hearts1 != null)
        {
            Destroy(Hearts1);
        }
        if(Hearts2 != null)
        {
            Destroy(Hearts2);
        }
        if (Hearts3 != null)
        {
            Destroy(Hearts3);
        }
    }
}
