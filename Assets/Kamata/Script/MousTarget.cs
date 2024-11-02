using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseTarget : MonoBehaviour
{
   
    [SerializeField]private Image cursorImage; // カーソルの画像
    [SerializeField]private Vector2 offset = new Vector2(10f, -10f); // マウス位置からのオフセット

    void Start()
    {
        // カーソルを非表示にする
        Cursor.visible = false;
    }

    void Update()
    {
        // マウスの位置を取得して、オフセットを適用
        Vector3 mousePosition = Input.mousePosition;
        cursorImage.transform.position = mousePosition + (Vector3)offset;
    }

    void OnDestroy()
    {
        // スクリプトが削除されたときにカーソルを表示に戻す
        Cursor.visible = true;
    }
}
