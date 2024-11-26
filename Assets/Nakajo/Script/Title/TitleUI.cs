using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0;
    [SerializeField] float addSpeed = 0;
    Vector3 targetPosition = new Vector3(960, 540, 0);
    [SerializeField] float stop = 0.01f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        if (distanceToTarget <= stop)
        {
            transform.position = targetPosition;
            return;
        }
        moveSpeed += addSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
