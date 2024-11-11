using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 背景を下にスクロールさせる
        transform.position += Vector3.down * Speed * Time.deltaTime;

        // 下まで行ったら上に戻す
        if (transform.position.y < -12f)
        {
            transform.Translate(new Vector3(0, 24f, 0));
        }
    }
}
