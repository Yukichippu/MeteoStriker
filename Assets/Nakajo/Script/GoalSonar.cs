using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalSonar : MonoBehaviour
{
    public Player player;   //Playerスクリプトを呼ぶやつ
    public ClearUI clearUI; //ClearUIスクリプトを呼ぶやつ

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        clearUI = GameObject.FindWithTag("GameClear").GetComponent<ClearUI>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            StartCoroutine(WaitGoalTime());
        }
    }

    private IEnumerator WaitGoalTime()
    {
        yield return new WaitForSeconds(7f);
        player.GoalPlayer();
        clearUI.isGoal();

        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Title");
    }
}
