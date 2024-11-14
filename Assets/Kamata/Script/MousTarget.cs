using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseTarget : MonoBehaviour
{
    [SerializeField] private Image cursorImage; // カーソルの画像
    [SerializeField] private Vector2 offset = new Vector2(10f, -10f); // マウス位置からのオフセット

    // カーソルの移動範囲（スクリーン座標で指定）
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    void Start()
    {
        // カーソルを非表示にする
        Cursor.visible = false;
    }

    void Update()
    {
        // マウスの位置を取得し、オフセットを適用
        Vector3 mousePosition = Input.mousePosition;

        // XとYの位置に制限をかける
        mousePosition.x = Mathf.Clamp(mousePosition.x, minX, maxX);
        mousePosition.y = Mathf.Clamp(mousePosition.y, minY, maxY);

        // カーソル画像の位置を更新
        cursorImage.transform.position = mousePosition + (Vector3)offset;
    }

    void OnDestroy()
    {
        // スクリプトが削除されたときにカーソルを表示に戻す
        Cursor.visible = true;
    }
}
