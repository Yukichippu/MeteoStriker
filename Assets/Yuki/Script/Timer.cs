using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float totalTime;
    //��������(��)
    [SerializeField] private int minute; 
    //��������(�b)
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

        //���͂��ꂽ�������Ԃ��v��
        totalTime = minute * 60 + second;
        totalTime -= Time.deltaTime;

        //���̍Đݒ�
        minute = (int)totalTime / 60;
        second = totalTime - minute * 60;

        //�^�C�}�[�\���pUI�e�L�X�g�Ɏ��Ԃ�\��
        if((int)second != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" +
                            ((int)second).ToString("00");
        }
        oldSeconds = second;

        if(totalTime <= 0f)
        {
            Debug.Log("�^�C���I�[�o�[");
        }
    }
}