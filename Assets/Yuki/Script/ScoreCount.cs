using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private string objTag;
    int score = 0;

    public void AddScore(int s)
    {
        Debug.Log(s);
        score += s;
        scoreText.text = "SCORE: " + score.ToString("");
        Debug.Log(score);
    }
   

    void Start()
    {
        score = 0;
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
