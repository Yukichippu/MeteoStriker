using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private string objTag;
    int score = 0;

    public void AddScore(int s)
    {
        Debug.Log(s);
        int prevScore = int.Parse(scoreText.text);

        prevScore += s;
        scoreText.text = prevScore.ToString("");
        Debug.Log(score);
    }
   
    void Start()
    {
        scoreText = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objTag = collision.gameObject.tag;
        Debug.Log(objTag);

        if(objTag == "Enemy")
        {
            gameObject.GetComponent<ScoreCount>().AddScore(30);
        }
        else if (objTag == "Enemy1")
        {
            gameObject.GetComponent<ScoreCount>().AddScore(50);
        }
        else if (objTag == "Enemy2")
        {
            gameObject.GetComponent<ScoreCount>().AddScore(100);
        }
    }
}
