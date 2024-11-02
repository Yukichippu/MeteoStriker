using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float posY = 10;

    void Update()
    {
        Vector3 start = transform.position;
        Vector3 target = new Vector3(0, posY, 0);
        float timer = 0;
        timer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(start, target, timer);
    }
}
