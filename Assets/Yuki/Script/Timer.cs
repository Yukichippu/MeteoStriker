using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float totalTime;
    //制限時間(分)
    [SerializeField] private int minute; 
    //制限時間(秒)
    [SerializeField] private float second;
    private float oldSeconds;
    private Text timerText;

    private void Start()
    {
        totalTime = minute * 60 + second;
        timerText = GetComponentInChildren<Text>();
        oldSeconds = 0f; 
    }
    void Update()
    {
        if(totalTime <= 0f)
        {
            return;
        }

        //入力された制限時間を計測
        totalTime = minute * 60 + second;
        totalTime -= Time.deltaTime;

        //↑の再設定
        minute = (int)totalTime / 60;
        second = totalTime - minute * 60;

        //タイマー表示用UIテキストに時間を表示
        if((int)second != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" +
                            ((int)second).ToString("00");
        }
        oldSeconds = second;

        if(totalTime <= 0f)
        {
            Debug.Log("タイムオーバー");
        }
    }
}