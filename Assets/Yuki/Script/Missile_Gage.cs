using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Missile_Gage : MonoBehaviour
{
    [SerializeField] Slider MissileGage; //UIのSliderをUnity内で挿入

    float missilePoint; //ゲージの値(現在の値)
    float maxMissilePoint = 1; //ゲージの最大値
    float waitSeconds = 0.2f; //リキャストタイム(1までに0.2につき1秒かかる)
    public Text valuetext;

    void Start()
    {
        missilePoint = maxMissilePoint;
        MissileGage.maxValue = maxMissilePoint;
    }

    void Update()
    {
        //マウスの左クリックが押されるかつ、ゲージの現在の値が最大値以上のときに現在の値を"0"にする
        if(Input.GetMouseButton(0) && missilePoint >= maxMissilePoint)
        {
            missilePoint = 0;
            Debug.Log("nice click");
        }
        //リキャストタイムの計算
        missilePoint += waitSeconds * Time.deltaTime;
        //現在の値をオブジェクトのValueに代入
        MissileGage.value = missilePoint;

        if(missilePoint <= maxMissilePoint)
        {
            valuetext.text = missilePoint.ToString("00") + "%";
        }
        else
        {
            print(valuetext.text);
            valuetext.text = ("MAX!!");
        }
    }

//    IEnumerator Wait()
//    {
//        yield return new WaitForSeconds(waitSeconds);
//    }
}
