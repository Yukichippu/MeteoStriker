using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private int LifeCount = 3;          //残機
    private bool Invincible = false;    //無敵かどうか
    private float InvincibleTime = 0;   //無敵時間のカウント
    private PolygonCollider2D Col;             //コライダーの取得
    private double time;
    [Tooltip("無敵の時間")][SerializeField] private float InvincibleEnd = 1f;
    [SerializeField] GameObject[] hearts;//のハート
    [SerializeField] private SpriteRenderer target;// 点滅させる対象
    [SerializeField] private float cycle = 1;// 点滅周期[s]
    [SerializeField] private AudioClip sound; //SE

    void Start()
    {
        Col = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (Invincible == true)
        {
            //Debug.Log("カウント開始");
            InvincibleTime += Time.deltaTime;
            EndInvincible();

            // 内部時刻を経過させる
            time += Time.deltaTime;
            if (time >= cycle)
            {
                target.enabled = !target.enabled;
                time = 0f;
            }
        }

        DeadPlayer();
    }

    //エネミーに当たったら
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2" && !Invincible)
        {
            //Debug.Log("残機ー１");
            LifeCount -= 1;
            PlayerLifeUI();
            //無敵関数呼び出し
            StartInvincible();
            //DeadPlayer();
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }

    //無敵開始の関数
    private void StartInvincible()
    {
        //Debug.Log("無敵開始");
        Invincible = true;
        //コライダーをOFF
        if (Invincible == true)
        {
            Col.enabled = false;
        }
    }

    //無敵終了の関数
    private void EndInvincible()
    {
        if (InvincibleTime > InvincibleEnd)
        {
            target.enabled = true;
            Invincible = false;
            //コライダーをON
            Col.enabled = true;
            time = 0f;
            InvincibleTime = 0;
        }
    }

    //プレイヤーの死亡を判断する関数
    private void DeadPlayer()
    {
        if (LifeCount == 0)
        {
            SceneManager.LoadScene("GameOver Scene");
            Destroy(this.gameObject);
        }
    }

    private void PlayerLifeUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i + 1 <= LifeCount) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
