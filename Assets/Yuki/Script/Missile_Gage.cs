using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Missile_Gage : MonoBehaviour
{
    [SerializeField] Slider MissileGage; //UI��Slider��Unity���ő}��
    [SerializeField] private Text valuetext; // ���݂̃`���[�W����\������Text

    [SerializeField] private Bomb bomb;  // 

    float chargeTime = 5f;
    float currentTime = 0f;
    bool isMaxGauge = false;

    void Start()
    {
        currentTime = chargeTime; // �Q�[���J�n���̓~�T�C����łĂ�悤��
        MissileGage.maxValue = chargeTime;
    }

    void Update()
    {
        //�}�E�X�̍��N���b�N��������邩�A�Q�[�W�̌��݂̒l���ő�l�ȏ�̂Ƃ��Ɍ��݂̒l��"0"�ɂ���
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
            //���L���X�g�^�C���̌v�Z
            currentTime += Time.deltaTime;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        //���݂̒l���I�u�W�F�N�g��Value�ɑ��
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
