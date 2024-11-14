using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayer : MonoBehaviour
{
    [SerializeField]private GameObject Goal;
    private float MoveSpeed = 3;
    bool isGoal = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(isGoal == true)
        {
            transform.position += Vector3.up * MoveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Goal)
        {
           isGoal = true;
            Debug.Log("‚ ‚½‚Á‚½");
        }
    }
}
