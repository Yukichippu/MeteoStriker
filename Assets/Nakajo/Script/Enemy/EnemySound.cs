using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EnemySound : MonoBehaviour
//{
    
//    [SerializeField] public EnemyMove enemyMove;

//    void Start()
//    {
        
//    }

//    void Update()
//    {
//        EbenySound();
//    }

//    public void EnemySound()
//    {
//        if (collision.gameObject.CompareTag("Bullet"))
//        {
//            currentHP--;

//            if (currentHP == 0)
//            {
//                GetComponent<AudioSource>().PlayOneShot(Dfsound);
//            }//HPが0になった時

//        }//弾に当たった時に消える処理

//        if (enemyMove.OnTriggerEnter2D())
//        {
//            if (this.gameObject.CompareTag("Bomb"))
//            {
//                if (enemyType == EnemyType.EX)
//                {
//                    currentHP--;
//                    if (currentHP == 0)
//                    {
//                        GetComponent<AudioSource>().PlayOneShot(EXsound);
//                    }
//                }//爆弾でしか倒せない敵の消滅処理
//            }
//        }
//    }
//}
