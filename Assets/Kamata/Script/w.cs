using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w : MonoBehaviour
{
    public float CameraSpeed = 5f; // 移動速度

    void Update()
    {
        // Y軸のプラス方向に移動
        Vector3 movement = new Vector3(0, CameraSpeed * Time.deltaTime, 0);
        transform.position += movement;
    }
}
