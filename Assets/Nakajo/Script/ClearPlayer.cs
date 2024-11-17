using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayer : MonoBehaviour
{
    [SerializeField]private float MoveSpeed = 0.4f;
    private float addSpeed = 0.035f;
    Vector3 targetPosition = new Vector3(0, 14, 0);

    void Update()
    {
        if(MoveSpeed < 5)
        {
            MoveSpeed += addSpeed;
        }
       
        Transform objectTransform = gameObject.GetComponent<Transform>();
        objectTransform.position = Vector3.Lerp(objectTransform.position, targetPosition, MoveSpeed * Time.deltaTime);
    }
}
