using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExpScript : MonoBehaviour
{
    float DestroyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //������Ɏ������폜
        DestroyCount += Time.deltaTime;
        if (DestroyCount > 1f)
        {
            Destroy(this.gameObject);
        }
    }
}
