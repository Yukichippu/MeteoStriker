using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score = 0;

    public void AddScore(int s)
    {
        score += s;
        scoreText.text = "SCORE: " + score.ToString("0000000");
    }

    void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<ScoreCount>().AddScore(100);
        }
    }
}
