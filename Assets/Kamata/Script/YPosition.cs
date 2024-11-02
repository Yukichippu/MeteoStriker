using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPosition : MonoBehaviour
{
    [SerializeField] private float minYPosition = 200f; // マウスのY座標の下限

    void Update()
    {
        // マウスのスクリーン座標を取得
        Vector3 mousePosition = Input.mousePosition;

        // Y座標がminYPositionより下であれば制限する
        if (mousePosition.y < minYPosition)
        {
            mousePosition.y = minYPosition;
        }

        // マウス座標をワールド座標に変換（例として）
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // オブジェクトの位置をマウスに追従させる場合の例
        transform.position = worldPosition;
    }
}
