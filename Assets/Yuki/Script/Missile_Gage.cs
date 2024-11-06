using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Missile_Gage : MonoBehaviour
{
    [SerializeField] Slider MissileGage; //UIのSliderをUnity内で挿入
    [SerializeField] private Text valuetext; // 現在のチャージ率を表示するText

    [SerializeField] private Bomb bomb;  // 

    float chargeTime = 5f;
    float currentTime = 0f;
    bool isMaxGauge = false;

    void Start()
    {
        currentTime = chargeTime; // ゲーム開始時はミサイルを打てるように
        MissileGage.maxValue = chargeTime;
    }

    void Update()
    {
        //マウスの左クリックが押されるかつ、ゲージの現在の値が最大値以上のときに現在の値を"0"にする
        if(Input.GetMouseButton(0) && isMaxGauge)
        {
            currentTime = 0f;
            isMaxGauge = false;
            bomb.ShootBomb();
        }
        MissileCharge();
    }

    private void MissileCharge()
    {
        if(isMaxGauge) { return; }

        if(currentTime >= chargeTime)
        {
            currentTime = chargeTime;
            isMaxGauge = true;
        }
        else
        {
            //リキャストタイムの計算
            currentTime += Time.deltaTime;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        //現在の値をオブジェクトのValueに代入
        MissileGage.value = currentTime;

        if (currentTime < chargeTime)
        {
            valuetext.text = (currentTime/chargeTime * 100f).ToString("00") + "%";
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
