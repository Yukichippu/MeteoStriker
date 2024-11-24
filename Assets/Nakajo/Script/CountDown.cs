using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text timeText;
    float countDown = 3.0f;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        countDown -= Time.deltaTime;
        timeText.text = countDown.ToString();
    }
}
