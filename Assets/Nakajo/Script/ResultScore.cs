using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField] private Text Rtext;
    private static ScoreCount scoreCount;
    private string RScore;

    void Update()
    {
        Debug.Log(scoreCount.GetScore());
        Rtext.text = scoreCount.GetScore().ToString();
    }
}
