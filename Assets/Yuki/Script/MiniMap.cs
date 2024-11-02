using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] GameObject target;

    void Update()
    {
        Vector3 target = GameObject.Find("FieldPlayer").transform.position;
        float y = target.y;
    }
}
