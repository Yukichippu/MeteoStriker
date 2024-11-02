using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Missile_Gage : MonoBehaviour
{
    [SerializeField] Slider MissileGage; //UI��Slider��Unity���ő}��

    float missilePoint; //�Q�[�W�̒l(���݂̒l)
    float maxMissilePoint = 1; //�Q�[�W�̍ő�l
    float waitSeconds = 0.2f; //���L���X�g�^�C��(1�܂ł�0.2�ɂ�1�b������)
    public Text valuetext;

    void Start()
    {
        missilePoint = maxMissilePoint;
        MissileGage.maxValue = maxMissilePoint;
    }

    void Update()
    {
        //�}�E�X�̍��N���b�N��������邩�A�Q�[�W�̌��݂̒l���ő�l�ȏ�̂Ƃ��Ɍ��݂̒l��"0"�ɂ���
        if(Input.GetMouseButton(0) && missilePoint >= maxMissilePoint)
        {
            missilePoint = 0;
            Debug.Log("nice click");
        }
        //���L���X�g�^�C���̌v�Z
        missilePoint += waitSeconds * Time.deltaTime;
        //���݂̒l���I�u�W�F�N�g��Value�ɑ��
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
