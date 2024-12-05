using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSonar : MonoBehaviour
{
    public Player player;
    public ClearUI clearUI;

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
        if(other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("�Ă΂ꂽ");
            player.GoalPlayer();
            clearUI.isGoal();  
        }
    }
}
