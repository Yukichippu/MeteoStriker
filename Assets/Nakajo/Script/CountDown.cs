using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Text countdownText;        //�J�E���g��\������R���|�[�l���g
    [SerializeField] private float delayCount = 1f;          //�������ς��Ԋu
    [SerializeField] private GameObject gameStartUI;    //�\������UI
    
    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(delayCount);
        }
        countdownText.gameObject.SetActive(false);

        if (gameStartUI != null)
        {
            gameStartUI.SetActive(true);
        }
    }
}
