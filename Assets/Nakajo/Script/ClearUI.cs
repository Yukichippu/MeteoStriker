using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearUI : MonoBehaviour
{
    [SerializeField ]private float MoveSpeed = 0.2f;
    Vector3 targetPosition = new Vector3(960, 540, 0);

    void Update()
    {
        Transform objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector3.Lerp(objectTransform.position, targetPosition, MoveSpeed * Time.deltaTime);
    }
}
