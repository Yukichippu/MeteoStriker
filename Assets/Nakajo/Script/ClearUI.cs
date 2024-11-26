using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearUI : MonoBehaviour
{
    [SerializeField ]private float MoveSpeed = 0.2f;    //動く速さ
    Vector3 targetPosition = new Vector3(960, 540, 0);  //この座標まで進む

    private bool OnMove = false;    //２秒経ったかを判定

    private void Start()
    {
        StartCoroutine(WaitAndStartMovement(2f));
    }
    void Update()
    {
        if (OnMove)
        {
            Transform objectTransform = gameObject.GetComponent<Transform>();
            objectTransform.position = Vector3.Lerp(objectTransform.position, targetPosition, MoveSpeed * Time.deltaTime);
        }
    }

    IEnumerator WaitAndStartMovement(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        OnMove = true;
    }
}
